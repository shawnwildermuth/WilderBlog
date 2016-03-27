using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace WilderBlog.Services
{
  public class LoggingMailService : IMailService
  {
    private ILogger<LoggingMailService> _logger;

    public LoggingMailService(ILogger<LoggingMailService> logger)
    {
      _logger = logger;
    }

    public Task SendMail(string template, string name, string email, string subject, string msg)
    {
      _logger.LogDebug($"Email Requested from {name} subject of {subject}");
      return Task.Delay(0);
    }
  }
}