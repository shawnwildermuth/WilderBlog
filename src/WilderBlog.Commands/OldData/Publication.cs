using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WilderBlog.OldData
{
  public class Publication
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string PublicationName { get; set; }
    public DateTime DatePublished { get; set; }
    public bool IsBook { get; set; }
    public string Comments { get; set; }

    [Display(Name = "Link")]
    [StringLength(250)]
    public string Link { get; set; }

    [Display(Name = "Publisher")]
    [StringLength(250)]
    public string Publisher { get; set; }
  }
}
