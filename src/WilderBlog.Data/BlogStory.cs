using System;
using System.Collections.Generic;

namespace WilderBlog.Data
{
  public class BlogStory
  {
    public string Body { get; set; }
    public ICollection<string> Categories { get; set; }
    public DateTime DatePublished { get; set; }
    public bool IsPublished { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string UniqueId { get; set; }
  }
}