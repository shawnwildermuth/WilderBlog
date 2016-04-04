using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WilderBlog.Services.DataProviders;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class BooksController : Controller
  {
    private PublicationsProvider _pubs;

    public BooksController(PublicationsProvider pubs)
    {
      _pubs = pubs;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View(_pubs.Get().Where(p => p.IsBook).ToList());
    }
  }
}
