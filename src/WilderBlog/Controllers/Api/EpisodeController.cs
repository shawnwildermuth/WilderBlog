using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WilderBlog.Services.DataProviders;

namespace WilderBlog.Controllers.Api
{
  [Route("/api/episodes")]
  public class EpisodeController : Controller
  {
    private PodcastEpisodesProvider _provider;
    const int PAGE_SIZE = 10;
    private ILogger<EpisodeController> _logger;

    public EpisodeController(PodcastEpisodesProvider podcastProvider, ILogger<EpisodeController> logger)
    {
      _provider = podcastProvider;
      _logger = logger;
    }

    IEnumerable<PodcastEpisode> LiveEpisodes => _provider.Get()
                                                  .Where(e => e.Status == PodcastEpisodeStatus.Live && e.PublishedDate <= DateTime.UtcNow)
                                                  .OrderBy(e => e.EpisodeNumber);

    [HttpGet("{page:int}")]
    public IActionResult Get(int page = 1, int pageSize = PAGE_SIZE)
    {
      try
      {
        var data = LiveEpisodes;

        var results = new
        {
          Success = true,
          ResultCount = data.Count(),
          Page = page,
          Results = data.Skip(pageSize * (page - 1)).Take(pageSize)
        };

        return Ok(results);
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to get episodes from the API", ex);
        return BadRequest();
      }

    }

    [HttpGet("{number:int}")]
    public IActionResult Get(int number)
    {
      try
      {
        var data = LiveEpisodes
                  .FirstOrDefault(e => e.EpisodeNumber == number);

        return Ok(data);
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to get episode from the API", ex);

        return BadRequest();
      }
    }

  }
}
