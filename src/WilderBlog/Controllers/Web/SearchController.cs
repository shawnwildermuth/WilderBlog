using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("")]
    public IActionResult Index()
    {
      ViewBag.Term = "";
      return View(new BlogResult());
    }

    [HttpGet("{term}/{page:int?}")]
    public IActionResult Pager(string term, int page = 1)
    {
      ViewBag.Term = term;

      var results = _repo.GetStoriesByTerm(term, 10, page);
      return View("Index", results);
    }
  }
}
