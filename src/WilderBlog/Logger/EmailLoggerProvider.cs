using System;
using Microsoft.Extensions.Logging;
using WilderBlog.Services;

namespace WilderBlog.Logger
{
  public class EmailLoggerProvider : ILoggerProvider
  {
    private readonly Func<string, LogLevel, bool> _filter;
    private readonly IMailService _mailService;

    public EmailLoggerProvider(Func<string, LogLevel, bool> filter, IMailService mailService)
    {
      _mailService = mailService;
      _filter = filter;
    }

    public ILogger CreateLogger(string categoryName)
    {
      return new EmailLogger(categoryName, _filter, _mailService);
    }

    public void Dispose()
    {
    }
  }
}
