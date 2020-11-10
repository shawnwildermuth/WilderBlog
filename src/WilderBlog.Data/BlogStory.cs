using System;
using System.Collections.Generic;

namespace WilderBlog.Data
{
  public class BlogStory
  {
    public int Id { get; set; }
    public string Body { get; set; }
    public string Categories { get; set; }
    public DateTime DatePublished { get; set; }
    public bool IsPublished { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public string UniqueId { get; set; }
    public string FeatureImageUrl { get; set; }
    public string Abstract { get; set; }
  }
}