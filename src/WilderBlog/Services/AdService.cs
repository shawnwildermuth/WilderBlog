using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WilderBlog.Models;

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
      var ranges = new List<AdDateRange>()
      {
        new AdDateRange( // Fallback
          DateTime.MinValue.ToString(),
          DateTime.MaxValue.ToString(),
          @"<a href=""//pluralsight.pxf.io/c/1191850/480966/7490"" id=""480966""><img src=""//a.impactradius-go.com/display-ad/7490-480966"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/480966/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595252/7490"" id=""595252""><img src=""//a.impactradius-go.com/display-ad/7490-595252"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595252/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595237/7490"" id=""595237""><img src=""//a.impactradius-go.com/display-ad/7490-595237"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595237/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//courses.wilderminds.com/p/vue-js-by-example""><img src=""/img/ads/vue-core-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//courses.wilderminds.com/p/bootstrap-4-by-example""><img src=""/img/ads/bootstrap4-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//courses.wilderminds.com/p/signalr""><img src=""/img/ads/signal-r-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//pluralsight.com/courses/aspnet-core-grpc""><img src=""/img/ads/grpc-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//pluralsight.com/courses/designing-restful-web-apis""><img src=""/img/ads/design-apis-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//pluralsight.com/courses/designing-restful-web-apis""><img src=""/img/ads/design-apis-468x60.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>"
        )

      };
      var now = DateTime.Now;
      var ads = ranges.Where(r => r.Start <= now && r.End >= now).FirstOrDefault();

      var item = new Random().Next(0, ads.Ads.Length);

  
      return new HtmlString(ads.Ads[item]);
    }

    public HtmlString SidebarAdd()
    {
      var ranges = new List<AdDateRange>()
      {
        new AdDateRange( // Fallback
          DateTime.MinValue.ToString(),
          DateTime.MaxValue.ToString(),
          @"<a href=""//pluralsight.pxf.io/c/1191850/431402/7490"" id=""431402""><img src=""//a.impactradius-go.com/display-ad/7490-431402"" border=""0"" alt="""" width=""250"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/431402/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595231/7490"" id=""595231""><img src=""//a.impactradius-go.com/display-ad/7490-595231"" border=""0"" alt="""" width=""250"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595231/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595246/7490"" id=""595246""><img src=""//a.impactradius-go.com/display-ad/7490-595246"" border=""0"" alt="""" width=""250"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595246/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.com/courses/aspnet-core-grpc""><img src=""/img/ads/grpc-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>",
          @"<a href=""//pluralsight.com/courses/designing-restful-web-apis""><img src=""/img/ads/design-apis-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>",
          @"<a href=""//courses.wilderminds.com/p/bootstrap-4-by-example""><img src=""/img/ads/bootstrap4-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>",
          @"<a href=""//courses.wilderminds.com/p/vue-js-by-example""><img src=""/img/ads/vue-core-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>",
          @"<a href=""//courses.wilderminds.com/p/signalr""><img src=""/img/ads/signal-r-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>",
          @"<a href=""//pluralsight.com/courses/aspnetcore-mvc-efcore-bootstrap-angular-web""><img src=""/img/ads/from-scratch-250x250.jpg"" border=""0"" alt="""" width=""250"" height=""250""/></a>"
        )

      };
      var now = DateTime.Now;
      var ads = ranges.Where(r => r.Start <= now && r.End >= now).FirstOrDefault();

      var item = new Random().Next(0, ads.Ads.Length);


      return new HtmlString(ads.Ads[item]);
    }

  }
}
