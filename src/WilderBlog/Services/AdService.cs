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

      var ads = new string[] {
        @"<a href=""//pluralsight.pxf.io/c/1191850/480967/7490""><img src=""//a.impactradius-go.com/display-ad/7490-480967"" border=""0"" alt="""" width=""728"" height=""90""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/480967/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
        @"<a href=""//pluralsight.pxf.io/c/1191850/512011/7490""><img src=""//a.impactradius-go.com/display-ad/7490-512011"" border=""0"" alt="""" width=""728"" height=""90""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/512011/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
        @"<a href=""//pluralsight.pxf.io/c/1191850/431407/7490""><img src=""//a.impactradius-go.com/display-ad/7490-431407"" border=""0"" alt="""" width=""728"" height=""90""/></a><img height=""0"" width=""0"" src=""//pluralsight.pxf.io/i/1191850/431407/7490"" style=""position:absolute;visibility:hidden;"" border=""0"" />",
        @"<a href=""//courses.wilderminds.com/p/vue-js-by-example""><img src=""/img/vue-ad.jpg"" border=""0"" alt="""" width=""728"" height=""90""/></a>",
        @"<a href=""//courses.wilderminds.com/p/bootstrap-4-by-example""><img src=""/img/bs-ad.jpg"" border=""0"" alt="""" width=""728"" height=""90""/></a>",
      };



      var item = new Random().Next(0, ads.Length);

  
      return new HtmlString(ads[item]);
    }

  }
}
