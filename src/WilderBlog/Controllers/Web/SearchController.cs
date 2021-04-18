using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class SearchController : Controller
  {
    private IWilderRepository _repo;
    private readonly ILogger<SearchController> _logger;

    public SearchController(IWilderRepository repo, ILogger<SearchController> logger)
    {
      _repo = repo;
      _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      ViewBag.Term = "";
      return View(new BlogResult());
    }

    [HttpGet("{term}/{page:int?}")]
    public async Task<IActionResult> Pager(string term, int page = 1)
    {
      ViewBag.Term = term;
      var results = new BlogResult();
      try
      {
        results = await _repo.GetStoriesByTerm(term, 15, page);
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to get search results: {term} - {ex}");
      }

      return View("Index", results);
    }
  }
}
