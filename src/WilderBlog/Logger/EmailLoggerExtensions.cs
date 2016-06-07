using System;
using Microsoft.Extensions.Logging;
using WilderBlog.Services;

namespace WilderBlog.Logger
{
  public static class EmailLoggerExtensions
  {
    public static ILoggerFactory AddEmail(this ILoggerFactory factory, 
                                          IMailService mailService, 
                                          Func<string, LogLevel, bool> filter = null)
    {
      factory.AddProvider(new EmailLoggerProvider(filter, mailService));
      return factory;
    }

    public static ILoggerFactory AddEmail(this ILoggerFactory factory, IMailService mailService, LogLevel minLevel)
    {
      return AddEmail(
          factory,
          mailService,
          (_, logLevel) => logLevel >= minLevel);
    }
  }
}
