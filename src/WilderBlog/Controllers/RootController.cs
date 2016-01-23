using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("")]
  public class RootController : Controller
  {
    private IWilderRepository _repo;

    public RootController(IWilderRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View(_repo.GetNewStories());
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
      return View();
    }

  }
}
