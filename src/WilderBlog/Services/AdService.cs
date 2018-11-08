using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WilderBlog.Services
{
  public class AdService
  {
    private IConfiguration _config;
    private readonly ILogger<AdService> _logger;

    public AdService(IConfiguration config, ILogger<AdService> logger)
    {
      _config = config;
      _logger = logger;
    }

    public HtmlString InlineAdd()
    {

      var ads = new Ad[]
      {
        new Ad()
        {
          Title = "Ready to Learn Vue with ASP.NET Core?",
          Message = "Shawn's 4-hour course will get you up to speed in no time. Vue.js is a great middle-ground between React and Angular for people who don't like the complexity of Angular, and the overly componentized React. Learn today at Wilder Minds Training!",
          Link = "//courses.wilderminds.com/p/vue-js-by-example"
        },
        new Ad()
        {
          Title = "Bootstrap 4 is Here!",
          Message = "After a long development cycle, Bootstrap has been completely re-written to improve performance and be more consistent.  Learn Bootstrap 4 now with my Wilder Minds course:",
          Link = "//courses.wilderminds.com/p/bootstrap-4-by-example"
        }
      };

      var item = new Random().Next(0, ads.Length);

      var text = $@"<div class='card ad-card col-md-6'>
    <h3 class='card-title'>{ads[item].Title}</h3>
    <p class='card-text'>{ads[item].Message}</p>
    <p><a href='{ads[item].Link}' class='btn btn-success'>Enroll Today</a></p>
</div>";

      return new HtmlString(text);
    }

    private class Ad
    {
      public string Title { get; internal set; }
      public string Message { get; internal set; }
      public string Link { get; internal set; }
    }
  }
}
