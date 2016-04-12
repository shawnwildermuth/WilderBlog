using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using WilderBlog.Commands.OldDb;
using WilderBlog.OldData;
using System.IO;
using System.Text;

namespace WilderBlog.Commands.Disqus
{
  public class DiscusImport
  {
    public void CreateXml(IEnumerable<Stories> stories)
    {
      var posts = stories.Where(c => c.IsPublished).OrderBy(c => c.DatePosted).ToArray();

      var i = 1;
      while (true)
      { 
        var file = string.Format(@"comments.xml", i);
        Console.Write($"Migrating Comments, Creating Export File # {i}");
        i++;

        var complete = DumpComments(file, posts);
        if (complete == posts.Count())
        {
          break;
        }
        posts = posts.Skip(complete).ToArray();
      }

      Console.WriteLine();
    }

    int DumpComments(string file, IEnumerable<Stories> posts)
    {
      XNamespace contentNS = "http://purl.org/rss/1.0/modules/content/";
      XNamespace dsqNS = "http://www.disqus.com/";
      XNamespace dcNS = "http://purl.org/dc/elements/1.1/";
      XNamespace wpNS = "http://wordpress.org/export/1.0/";

      var channel = new XElement("channel");
      var root = new XElement("rss",
        new XAttribute("version", "2.0"),
        new XAttribute(XNamespace.Xmlns + "content", contentNS),
        new XAttribute(XNamespace.Xmlns + "dsq", dsqNS),
        new XAttribute(XNamespace.Xmlns + "dc", dcNS),
        new XAttribute(XNamespace.Xmlns + "wp", wpNS),
        channel
      );

      var complete = 0;
      foreach (var p in posts)
      {
        var item = new XElement("item",
          new XElement("title", p.Title),
          new XElement("link", $"http://wildermuth.com/{p.GetStoryUrl()}"),
          new XElement(contentNS + "encoded", null),
          new XElement(dsqNS + "thread_identifier", p.Permalink != null ? p.Permalink : p.GetStoryUrl()),
          new XElement(wpNS + "post_date_gmt", p.DatePosted.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")),
          new XElement(wpNS + "comment_status", p.DatePosted.AddDays(90) > DateTime.Today ? "open" : "closed")
        );

        foreach (var c in p.Comments.Where(c => c.IsApproved))
        {
          item.Add(new XElement(wpNS + "comment",
            new XElement(wpNS + "comment_id", c.Id),
            new XElement(wpNS + "comment_author", SafeContent(c.PosterName, 50)), // Disqus allows 75, but we're trimming extra for HTML encoding expansion
            new XElement(wpNS + "comment_author_email", SafeContent(c.PosterEmail, 50)), // ditto
            new XElement(wpNS + "comment_author_url", null),
            new XElement(wpNS + "comment_author_IP", null),
            new XElement(wpNS + "comment_date_gmt", c.DatePosted.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss")),
            new XElement(wpNS + "comment_content", SafeContent(c.Body, 25000, 3)),
            new XElement(wpNS + "comment_approved", c.IsApproved ? 1 : 0),
            new XElement(wpNS + "comment_parent", 0)
          ));
        }

        channel.Add(item);

        if (IsTooLong(root))
        {
          item.Remove();
          break;
        }
        else
        {
          complete++;
        }
      }

      // serialize to XML
      var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
      doc.Add(root);

      File.WriteAllText(file, Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(doc.ToString())));

      return complete;
    }

    private bool IsTooLong(XElement root)
    {
      var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));
      doc.Add(root);
      var len = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(doc.ToString())).Length;

      return len > (1024 * 1024 * 20);
    }

    // Define other methods and classes here
    string SafeContent(string s, int maxLength = int.MaxValue, int minLength = 0)
    {
      if (s == null) { s = ""; }
      s = s
          .Replace(((char)0x0).ToString(), "")
          .Replace(((char)0x1).ToString(), "")
          .Replace(((char)0xb).ToString(), "")
          .Replace(((char)0x19).ToString(), "")
          .Replace(((char)0x1b).ToString(), "")
          ;
      s = s.Trim();
      if (s.Length < minLength) { s += new string('-', minLength - s.Length); }
      return s.Substring(0, Math.Min(s.Length, maxLength));
    }
  }
}