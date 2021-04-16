using System;

namespace WilderBlog.Data
{
  public enum EpisodeStatus
  {
    Planned,
    Live,
    Staged
  }

  public class Episode
  {
    public string[] Blurb { get; set; } = new string[0];
    public int EpisodeNumber { get; set; }
    public string GuestName { get; set; } = "";
    public string[] GuestBio { get; set; } = new string[0];
    public string GuestHeadshot { get; set; } = "";
    public string GuestFirstMachine { get; set; } = "";
    public string GuestFirstMachineName { get; set; } = "";
    public string GuestFirstMachineLink { get; set; } = "";
    public EpisodeLink[] GuestLinks { get; set; } = new EpisodeLink[0];
    public string PodcastName { get; set; } = "";
    public string AudioLink { get; set; } = "";
    public DateTime PublishedDate { get; set; }
    public EpisodeStatus Status { get; set; }
    public TimeSpan Length { get; set; }
    public string YouTubeLink { get; set; } = "";

    public string Slug()
    {
      return string.Concat(EpisodeNumber, "_", GuestName.Replace(" ", "_"));
    }
  }
}