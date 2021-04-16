using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WilderBlog.Services;

namespace WilderBlog.Logger
{
  public static class EmailLoggerExtensions
  {
    public static ILoggerFactory AddEmail(this ILoggerFactory factory, 
                                          IMailService mailService, 
                                          IHttpContextAccessor contextAccessor,
                                          Func<string, LogLevel, bool>? filter = null)
    {
#pragma warning disable CS8604 // Possible null reference argument.
      factory.AddProvider(new EmailLoggerProvider(filter, mailService, contextAccessor));
#pragma warning restore CS8604 // Possible null reference argument.
      return factory;
    }

    public static ILoggerFactory AddEmail(this ILoggerFactory factory, 
      IMailService mailService,
      IHttpContextAccessor contextAccessor, 
      LogLevel minLevel)
    {
      return AddEmail(
          factory,
          mailService,
          contextAccessor,
          (_, logLevel) => logLevel >= minLevel);
    }
  }
}
