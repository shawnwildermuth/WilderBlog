using System.Linq;
using Microsoft.AspNet.Mvc;
using WilderBlog.Services.DataProviders;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class VideosController : Controller
  {
    private VideosProvider _videos;

    public VideosController(VideosProvider videos)
    {
      _videos = videos;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View(_videos.Get());
    }

    [HttpGet("{id:int}")]
    public IActionResult Video(int id)
    {
      var result = _videos.Get().Where(v => v.Id == id).FirstOrDefault();
      if (result == null) return RedirectToAction("Index");
      return View(result);
    }


  }
}
