using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class TagController : Controller
  {
    private IWilderRepository _repo;
    private readonly ILogger<TagController> _logger;
    readonly int _pageSize = 25;

    public TagController(IWilderRepository repo, ILogger<TagController> logger)
    {
      _repo = repo;
      _logger = logger;
    }

    [HttpGet("{tag}")]
    public Task<IActionResult> Index(string tag)
    {
      return Pager(tag, 1);
    }

    [HttpGet("{tag}/{page}")]
    public async Task<IActionResult> Pager(string tag, int page)
    {
      BlogResult result = new();

      try
      {
        result = await _repo.GetStoriesByTag(tag, _pageSize, page);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to load Tags: {tag} - {ex}");
        
      }

      return View("Index", result);
    }
  }
}