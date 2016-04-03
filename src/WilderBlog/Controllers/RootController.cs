using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WilderBlog.Data;
using WilderBlog.Models;
using WilderBlog.Services;

namespace WilderBlog.Controllers
{
  [Route("")]
  public class RootController : Controller
  {
    private IMailService _mailService;
    private IWilderRepository _repo;

    public RootController(IMailService mailService, IWilderRepository repo)
    {
      _mailService = mailService;
      _repo = repo;
    }

    [HttpGet("{page:int?}")]
    public IActionResult Index(int page = 1)
    {
      var pageSize = 10;

      ViewBag.TotalPages = _repo.GetStoryPageCount(pageSize);
      return View(_repo.GetStories(pageSize, page));
    }

    [HttpGet("tag/{id}")]
    public IActionResult Tag(string id)
    {
      // TODO Add Tag Search



      var pageSize = 10;

      ViewBag.TotalPages = _repo.GetStoryPageCount(pageSize);
      return View(_repo.GetStories(pageSize, 0));
    }

    [HttpGet("{year:int}/{month:int}/{day:int}/{slug}")]
    public IActionResult Story(int year, int month, int day, string slug)
    {
      var fullSlug = $"{year}/{month}/{day}/{slug}";

      var story = _repo.GetStory(fullSlug);

      if (story == null) Redirect("/");

      return View(story);
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
      return View();
    }

    [HttpPost("contact")]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact([FromBody]ContactModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _mailService.SendMail("ContactTemplate.txt", model.Name, model.Email, model.Subject, model.Msg);

          return Ok(new { Success = true, Message = "Message Sent" });
        }
        else
        {
          ModelState.AddModelError("", "Failed to send email");
          return HttpBadRequest(ModelState);
        }
      }
      catch (Exception)
      {
        // TODO
        return HttpBadRequest(new { Reason = "Error Occurred" });
      }

    }
  }
}
