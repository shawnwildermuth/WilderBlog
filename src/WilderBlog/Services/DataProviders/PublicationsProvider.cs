using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace WilderBlog.Services.DataProviders
{
  public class PublicationsProvider : DataProvider<Publication>
  {
    public PublicationsProvider(IHostingEnvironment env) 
      : base(env, "publications.json")
    {
    }

    public override IEnumerable<Publication> Get()
    {
      return base.Get().OrderByDescending(p => p.DatePublished).ToList();
    }
  }

  public class Publication
  {
    public int Id { get; set; }
    public string PublicationName { get; set; }
    public string Publisher { get; set; }
    public DateTime DatePublished { get; set; }
    public string Comments { get; set; }
    public bool IsBook { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
  }
}
