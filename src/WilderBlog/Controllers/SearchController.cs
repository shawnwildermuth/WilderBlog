using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class SearchController : Controller
  {
    private IWilderRepository _repo;

    public SearchController(IWilderRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("{term}/{page:int?}")]
    public IActionResult Get(string term, int page = 0)
    {
      // TODO Change to search
      var results = _repo.GetStories(10, page);
      return View(results);
    }
  }
}
