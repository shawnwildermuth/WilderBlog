using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WilderBlog.Filters
{
  public class WilderExceptionFilter : ExceptionFilterAttribute
  {
    private readonly IHostingEnvironment _hostingEnvironment;

    public WilderExceptionFilter(IHostingEnvironment hostingEnvironment)
    {
      _hostingEnvironment = hostingEnvironment;
    }

    public override void OnException(ExceptionContext context)
    {
      if (_hostingEnvironment.IsDevelopment())
      {
        return;
      }
      
      
    }
  }
}
