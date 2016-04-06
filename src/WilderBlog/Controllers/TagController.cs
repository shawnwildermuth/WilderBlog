using Microsoft.AspNet.Mvc;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class TagController : Controller
  {
    private IWilderRepository _repo;
    readonly int _pageSize = 25;

    public TagController(IWilderRepository repo)
    {
      _repo = repo;
    }

    [HttpGet("{tag}/{page:int?}")]
    public IActionResult Index(string tag, int page = 1)
    {
      return View(_repo.GetStoriesByTag(tag, _pageSize, page));
    }
  }
}