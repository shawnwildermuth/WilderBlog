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
  public class EmailLoggerProvider : ILoggerProvider
  {
    private readonly Func<string, LogLevel, bool> _filter;
    private readonly IMailService _mailService;
    private readonly IHttpContextAccessor _contextAccessor;

    public EmailLoggerProvider(Func<string, LogLevel, bool> filter, IMailService mailService, IHttpContextAccessor contextAccessor)
    {
      _mailService = mailService;
      _contextAccessor = contextAccessor;
      _filter = filter;
    }

    public ILogger CreateLogger(string categoryName)
    {
      return new EmailLogger(categoryName, _filter, _mailService, _contextAccessor);
    }

    public void Dispose()
    {
    }
  }
}
