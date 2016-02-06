using System.ComponentModel.DataAnnotations;
using System;

namespace WilderBlog.OldData
{
  public class Comment
  {
    public int Id { get; set; }

    public string PosterName { get; set; }
    public string PosterEmail { get; set; }
    public DateTime DatePosted { get; set; }
    public bool IsApproved { get; set; }
    public string Body { get; set; }

    public virtual Story Story { get; set; }
  }
}