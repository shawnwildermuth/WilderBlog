using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WilderBlog.Data;

namespace WilderBlog.Helpers
{
  public static class DataExtensions
  {
    
    public static string GetSummary(this BlogStory me)
    {
      var MAXPARAGRAPHS = 2;
      var regex = new Regex("(<p[^>]*>.*?</p>)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
      var result = regex.Matches(me.Body);
      StringBuilder bldr = new StringBuilder();
      var x = 0;
      foreach (Match m in result)
      {
        x++;
        bldr.Append(m.Value);
        if (x == MAXPARAGRAPHS) break;
      }
      return bldr.ToString();

    }

    public static string GetStoryUrl(this BlogStory story)
    {
      return string.Format("{0:0000}/{1:00}/{2:00}/{3}", story.DatePublished.Year, story.DatePublished.Month, story.DatePublished.Day, GetUrlSafeTitle(story));
    }

    //public static Uri GetStoryFullUri(this BlogStory story, HttpRequest request)
    //{
    //  return new Uri(new Uri(request.GetDisplayUrl()), story.GetStoryUrl());
    //}

    public static string GetUrlSafeTitle(this BlogStory story)
    {
      // Characters to replace with underscore
      char[] replacements = @" ""'?*.,+&:;\/#".ToCharArray();

      string[] splits = story.Title.Split(replacements, StringSplitOptions.RemoveEmptyEntries);
      StringBuilder bldr = new StringBuilder();
      foreach (string s in splits)
      {
        bldr.Append(s);
        bldr.Append("-");
      }
      return bldr.ToString(0, bldr.Length - 1);
    }

  }
}
