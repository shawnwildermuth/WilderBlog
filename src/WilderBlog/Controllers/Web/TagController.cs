using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

    [HttpGet("{tag}")]
    public Task<IActionResult> Index(string tag)
    {
      return Pager(tag, 1);
    }

    [HttpGet("{tag}/{page}")]
    public async Task<IActionResult> Pager(string tag, int page)
    {
      return View("Index", await _repo.GetStoriesByTag(tag, _pageSize, page));
    }
  }
}