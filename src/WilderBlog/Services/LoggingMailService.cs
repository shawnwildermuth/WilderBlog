using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WilderBlog.Services
{
  public class LoggingMailService : IMailService
  {
    private ILogger<LoggingMailService> _logger;

    public LoggingMailService(ILogger<LoggingMailService> logger)
    {
      _logger = logger;
    }

    public Task<bool> SendMailAsync(string template, string name, string email, string subject, string msg, string phone = "")
    {
      _logger.LogDebug($"Email Requested from {name} subject of {subject}");
      return Task.FromResult(true);
    }
  }
}