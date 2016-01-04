using System;
using System.Collections.Generic;

namespace WilderBlog.Data
{
  public class Story
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DatePosted { get; set; }
    public string Permalink { get; set; }
    public bool IsPublished { get; set; }
    public virtual ICollection<Category> Categories { get; set; }

  }
}