using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using WilderBlog.Commands.OldDb;

namespace WilderBlog.OldData
{
  public static class EntityExtensions
  {
    public static string GetStoryUrl(this Stories story)
    {
      return string.Format("{0:0000}/{1:00}/{2:00}/{3}", story.DatePosted.Year, story.DatePosted.Month, story.DatePosted.Day, GetSlug(story));
    }

    public static Uri GetStoryFullUri(this Stories story, HttpRequest request)
    {
      return new Uri(new Uri(request.GetDisplayUrl()), string.Format("/{0:0000}/{1:00}/{2:00}/{3}", story.DatePosted.Year, story.DatePosted.Month, story.DatePosted.Day, GetSlug(story)));
    }

    public static string GetSlug(this Stories story)
    {
      // Characters to replace with underscore
      char[] replacements = @" ""'?*.,+&:;\/#".ToCharArray();

      string[] splits = story.Title.Split(replacements, StringSplitOptions.RemoveEmptyEntries);
      StringBuilder bldr = new StringBuilder();
      foreach (string s in splits)
      {
        bldr.Append(s);
        bldr.Append("_");
      }
      return bldr.ToString(0, bldr.Length - 1);
    }


  }
}
