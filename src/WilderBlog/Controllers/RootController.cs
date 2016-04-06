using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http.Extensions;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using WilderBlog.Data;
using WilderBlog.Models;
using WilderBlog.Services;
using WilderMinds.RssSyndication;

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

    [HttpGet("")]
    public IActionResult Index()
    {
      return Pager(1);
    }

    [HttpGet("blog/{page:int?}")]
    public IActionResult Pager(int page)
    {
      var pageSize = 25;

      return View("Index", _repo.GetStories(pageSize, page));
    }


    [HttpGet("tag/{id}")]
    public IActionResult Tag(string id)
    {
      // TODO Add Tag Search

      var pageSize = 10;

      return View(_repo.GetStories(pageSize, 0));
    }

    [HttpGet("{year:int}/{month:int}/{day:int}/{slug}")]
    public IActionResult Story(int year, int month, int day, string slug)
    {
      var fullSlug = $"{year}/{month}/{day}/{slug}";

      var story = _repo.GetStory(fullSlug);

      if (story == null) return Redirect("/");

      return View(story);
    }

    [HttpGet("about")]
    public IActionResult About()
    {
      return View();
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

    [HttpGet("rss")]
    public IActionResult Rss()
    {
      return RedirectPermanent("http://feeds.feedburner.com/ShawnWildermuth");
    }

    [HttpGet("feed")]
    public IActionResult Feed()
    {
      var feed = new Feed()
      {
        Title = "Shawn Wildermuth's Blog",
        Description = "My Favorite Rants and Raves",
        Link = new Uri("http://wildermuth.com/feed"),
        Copyright = "© 2016 Wilder Minds LLC"
      };

      var license = @"<div>
        <div style=""float: left;"">
          <a rel=""license"" href=""http://creativecommons.org/licenses/by-nc-nd/3.0/"">
            <img alt=""Creative Commons License"" style=""border-width: 0"" src=""http://i.creativecommons.org/l/by-nc-nd/3.0/88x31.png"" /></a></div>
        <div>
          This work by <a xmlns:cc=""http://creativecommons.org/ns#"" href=""http://wildermuth.com""
            property=""cc:attributionName"" rel=""cc:attributionURL"">Shawn Wildermuth</a> is
          licensed under a <a rel=""license"" href=""http://creativecommons.org/licenses/by-nc-nd/3.0/"">
            Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License</a>.<br />
          Based on a work at <a xmlns:dct=""http://purl.org/dc/terms/"" href=""http://wildermuth.com""
            rel=""dct:source"">wildermuth.com</a>.</div>
        </div>";
      var ad = @"<hr/><div>If you liked this article, see Shawn's courses on <a href=""http://shawnw.me/psauthor"">Pluralsight</a>.</div>";

      var entries = _repo.GetStories(25);

      foreach (var entry in entries.Stories)
      {
        var item = new Item()
        {
          Title = entry.Title,
          Body = string.Concat(entry.Body, license, ad),
          Link = new Uri(new Uri(Request.GetEncodedUrl()), entry.Slug),
          Permalink = entry.Slug,
          PublishDate = entry.DatePublished,
          Author = new Author() { Name = "Shawn Wildermuth", Email = "shawn@wildermuth.com" }
        };

        foreach (var cat in entry.Categories.Split(','))
        {
          item.Categories.Add(cat);
        }
        feed.Items.Add(item);
      }

      return File(Encoding.UTF8.GetBytes(feed.Serialize()), "text/xml");

    }

  }
}
