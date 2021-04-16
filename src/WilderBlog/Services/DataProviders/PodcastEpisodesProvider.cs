using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WilderBlog.Services.DataProviders
{
  public class PodcastEpisodesProvider : DataProvider<PodcastEpisode>
  {
    public PodcastEpisodesProvider(IHostEnvironment env)
      : base(env, "episodeList.json")
    {
    }

    public override IEnumerable<PodcastEpisode> Get()
    {
      return base.Get().OrderByDescending(a => a.PublishedDate).ToList();
    }
  }

  public class PodcastEpisode
  {
    public string[] Blurb { get; set; } = new string[0];
    public int EpisodeNumber { get; set; }
    public string[] GuestBio { get; set; } = new string[0];
    public string GuestName { get; set; } = "";
    public string GuestHeadshot { get; set; } = "";
    public string GuestFirstMachineImage { get; set; } = "";
    public string GuestFirstMachineLink { get; set; } = "";
    public string GuestFirstMachineName { get; set; } = "";
    public ICollection<GuestLink> GuestLinks { get; set; } = new List<GuestLink>();
    public string PodcastName { get; set; } = "";
    public string AudioLink { get; set; } = "";
    public DateTime PublishedDate { get; set; }
    public string YouTubeLink { get; set; } = "";
    public PodcastEpisodeStatus Status { get; set; }
  }

  public enum PodcastEpisodeStatus
  {
    Planned,
    Live,
    Staged
  }

  public class GuestLink
  {
    public string Name { get; set; } = "";
    public string Link { get; set; } = "";
  }
}
