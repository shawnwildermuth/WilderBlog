using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;

namespace WilderBlog.Services.DataProviders
{
  public class VideosProvider : DataProvider<Video>
  {
    public VideosProvider(IApplicationEnvironment env) 
      : base(env, "videos.json")
    {
    }

    public override IEnumerable<Video> Get()
    {
      return base.Get().OrderByDescending(p => p.DatePublished).ToList();
    }
  }

  public enum VideoType
  {
    Unknown = 0,
    YouTube,
    Channel9,
    Vimeo
  }

  public class Video
  {
    public string Title { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public string VideoCode { get; set; }
    public VideoType VideoType { get; set; }
    public DateTime DatePublished { get; set; }
  }
}
