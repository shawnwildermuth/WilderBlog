using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WilderBlog.Data;
using WilderBlog.Services.DataProviders;

namespace WilderBlog.Controllers
{
  [Route("hwpod")]
  public class PodcastController : Controller
  {
    private PodcastEpisodesProvider _podcastProvider;

    public PodcastController(PodcastEpisodesProvider podcastProvider)
    {
      _podcastProvider = podcastProvider;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      var episodes = _podcastProvider.Get();
      var latest = _podcastProvider.Get().Where(e => e.Status == PodcastEpisodeStatus.Live &&
                                       e.PublishedDate.AddHours(14) <= DateTime.UtcNow)
                           .OrderByDescending(e => e.EpisodeNumber)
                           .FirstOrDefault();

      return View(Tuple.Create<PodcastEpisode, IEnumerable<PodcastEpisode>>(latest, episodes));
    }

    [HttpGet("{id:int}/{tag}")]
    public IActionResult Episode(int id, string tag)
    {
      var episode = _podcastProvider.Get()
                                     .Where(e => e.Status == PodcastEpisodeStatus.Live && 
                                                 e.EpisodeNumber == id)
                                     .FirstOrDefault();

      if (episode == null) return RedirectToAction("Index");

      return View(episode);
    }
  }
}
