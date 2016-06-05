using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WilderBlog.Data;
using WilderBlog.Models;
using WilderBlog.Services;
using WilderMinds.RssSyndication;

namespace WilderBlog.Controllers
{
  [Route("")]
  public class RootController : Controller
  {
    readonly int _pageSize = 25;

    private IMailService _mailService;
    private IWilderRepository _repo;
    private IMemoryCache _memoryCache;
    private ILogger<RootController> _logger;

    public RootController(IMailService mailService, 
                          IWilderRepository repo, 
                          IMemoryCache memoryCache, 
                          ILogger<RootController> logger)
    {
      _mailService = mailService;
      _repo = repo;
      _memoryCache = memoryCache;
      _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return Pager(1);
    }

    [HttpGet("blog/{page:int?}")]
    public IActionResult Pager(int page)
    {
      return View("Index", _repo.GetStories(_pageSize, page));
    }

    [HttpGet("{year:int}/{month:int}/{day:int}/{slug}")]
    public IActionResult Story(int year, int month, int day, string slug)
    {
      var fullSlug = $"{year}/{month}/{day}/{slug}";

      try
      {
        var story = _repo.GetStory(fullSlug);

        // Try with other slug if it doesn't work
        if (story == null) story = _repo.GetStory($"{year:0000}/{month:00}/{day:00}/{slug}");

        if (story != null) return View(story);
      }
      catch
      {
        _logger.LogWarning($"Couldn't find the ${fullSlug} story");
      }

      return Redirect("/");

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
          return BadRequest(ModelState);
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to send email from contact page", ex);
        return BadRequest(new { Reason = "Error Occurred" });
      }

    }

    [HttpGet("rss")]
    public IActionResult Rss()
    {
      return RedirectPermanent("http://feeds.feedburner.com/ShawnWildermuth");
    }

    [HttpGet("Error/{code:int}")]
    public IActionResult Error(int errorCode)
    {
      if (Response.StatusCode == (int)HttpStatusCode.NotFound ||
          errorCode == (int)HttpStatusCode.NotFound ||
          Request.Path.Value.EndsWith("404"))
      {
        return View("NotFound");
      }

      return View();
    }

    [HttpGet("Exception")]
    public IActionResult Exception()
    {
      var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
      var request = HttpContext.Features.Get<IHttpRequestFeature>();

      if (exception != null && request != null)
      {
        var message = $@"RequestUrl: ${request.Path}

Exception: ${exception.Error}";

        _mailService.SendMail("logmessage.txt", "Shawn Wildermuth", "shawn@wildermuth.com", "[WilderBlog Exception]", message);
      }

      return View();
    }

    [HttpGet("testerror")]
    public IActionResult TestError()
    {
      throw new InvalidOperationException("Failure");
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

    [HttpGet("psstats")]
    public async Task<IActionResult> PsStats()
    {
      var CACHEKEY = "PSSTATS";
      string cached;
      
      if (!_memoryCache.TryGetValue(CACHEKEY, out cached))
      { 
        var client = new HttpClient();
        cached = await client.GetStringAsync(new Uri("http://www.pluralsight.com/data/Courses/Popular"));
        _memoryCache.Set(CACHEKEY, cached,new MemoryCacheEntryOptions() { SlidingExpiration = TimeSpan.FromHours(2) });
      }

      var converter = new ExpandoObjectConverter();
      dynamic courses = JsonConvert.DeserializeObject<IEnumerable<ExpandoObject>>(cached, converter);

      return View(courses);

    }

  }
}
