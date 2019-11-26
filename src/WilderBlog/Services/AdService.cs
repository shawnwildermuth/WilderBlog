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
        new AdDateRange(
          "2019/11/29", 
          "2019/12/01",
          @"<a href=""//pluralsight.pxf.io/c/1191850/714573/7490"" id=""714573""><img src=""//a.impactradius-go.com/display-ad/7490-714573"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/714573/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />"),
        new AdDateRange(
          "2019/12/01",
          "2019/12/06",
          @"<a href=""//pluralsight.pxf.io/c/1191850/714551/7490"" id=""714551""><img src=""//a.impactradius-go.com/display-ad/7490-714551"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/714551/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />"),
        new AdDateRange( // Fallback
          DateTime.MinValue.ToString(),
          DateTime.MaxValue.ToString(),
          @"<a href=""//pluralsight.pxf.io/c/1191850/480966/7490"" id=""480966""><img src=""//a.impactradius-go.com/display-ad/7490-480966"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/480966/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595252/7490"" id=""595252""><img src=""//a.impactradius-go.com/display-ad/7490-595252"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595252/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595237/7490"" id=""595237""><img src=""//a.impactradius-go.com/display-ad/7490-595237"" border=""0"" alt="""" width=""468"" height=""60""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595237/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//courses.wilderminds.com/p/vue-js-by-example""><img src=""/img/vue-ad.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>",
          @"<a href=""//courses.wilderminds.com/p/bootstrap-4-by-example""><img src=""/img/bs-ad.jpg"" border=""0"" alt="""" width=""468"" height=""60""/></a>")

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
        new AdDateRange(
          "2019/11/29",
          "2019/12/01",
          @"<a href=""//pluralsight.pxf.io/c/1191850/714568/7490"" id=""714568""><img src=""//a.impactradius-go.com/display-ad/7490-714568"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/714568/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />"),
        new AdDateRange(
          "2019/12/01",
          "2019/12/06",
          @"<a href=""//pluralsight.pxf.io/c/1191850/714546/7490"" id=""714546""><img src=""//a.impactradius-go.com/display-ad/7490-714546"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/714546/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />"),
        new AdDateRange( // Fallback
          DateTime.MinValue.ToString(),
          DateTime.MaxValue.ToString(),
          @"<a href=""//pluralsight.pxf.io/c/1191850/480964/7490"" id=""480964""><img src=""//a.impactradius-go.com/display-ad/7490-480964"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/480964/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/431403/7490"" id=""431403""><img src=""//a.impactradius-go.com/display-ad/7490-431403"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/431403/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595232/7490"" id=""595232""><img src=""//a.impactradius-go.com/display-ad/7490-595232"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595232/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
          @"<a href=""//pluralsight.pxf.io/c/1191850/595247/7490"" id=""595247""><img src=""//a.impactradius-go.com/display-ad/7490-595247"" border=""0"" alt="""" width=""300"" height=""250""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/595247/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />"
        )

      };
      var now = DateTime.Now;
      var ads = ranges.Where(r => r.Start <= now && r.End >= now).FirstOrDefault();

      var item = new Random().Next(0, ads.Ads.Length);


      return new HtmlString(ads.Ads[item]);
    }

  }
}
