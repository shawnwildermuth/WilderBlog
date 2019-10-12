using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace WilderBlog.Filters
{
  public class WilderExceptionFilter : ExceptionFilterAttribute
  {
    private readonly IHostEnvironment _hostingEnvironment;

    public WilderExceptionFilter(IHostEnvironment hostingEnvironment)
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
