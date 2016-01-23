using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WilderBlog.Controllers
{
  [Route("books")]
  public class BooksController : Controller
  {
    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }
  }
}
