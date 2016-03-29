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
  public class PodcastEpisodesProvider : DataProvider<PodcastEpisode>
  {
    public PodcastEpisodesProvider(IApplicationEnvironment env)
      : base(env, "publications.json")
    {
    }

    public override IEnumerable<PodcastEpisode> Get()
    {
      return base.Get().OrderByDescending(a => a.PublishedDate).ToList();
    }
  }

  public class PodcastEpisode
  {
    public string Blurb { get; set; }
    public int EpisodeNumber { get; set; }
    public string[] GuestBio { get; set; }
    public string GuestHeadshot { get; set; }
    public string GuestFirstMachine { get; set; }
    public string GuestFirstMachineLink { get; set; }
    public string GuestFirstMachineName { get; set; }
    public ICollection<GuestLink> GuestLinks { get; set; }
    public string PodcastName { get; set; }
    public string AudioLink { get; set; }
    public DateTime PublishedDate { get; set; }
    public string YouTubeLink { get; set; }
    public PodcastEpisodeStatus Status { get; set; }
  }

  public enum PodcastEpisodeStatus
  {
    Invalid = 0,
    Live = 1,
    Planned = 2
  }

  public class GuestLink
  {
    public string Name { get; set; }
    public string Link { get; set; }
  }
}
