using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WilderBlog.Services
{
  public class MailService : IMailService
  {
    private IConfiguration _config;
    private IHostEnvironment _env;
    private ILogger<MailService> _logger;

    public MailService(IHostEnvironment env, IConfiguration config, ILogger<MailService> logger)
    {
      _env = env;
      _config = config;
      _logger = logger;
    }

    public async Task<bool> SendMailAsync(string template, string name, string email, string subject, string msg)
    {
      try
      {
        var path = Path.Combine(_env.ContentRootPath, "EmailTemplates", template);
        if (!File.Exists(path))
        {
          _logger.LogError("Cannot find email templates");
        }

        var body = File.ReadAllText(path);

        var key = _config["MailService:ApiKey"];

        var client = new SendGridClient(key);
        var formattedMessage = string.Format(body, email, name, subject, msg);

        var mailMsg = MailHelper.CreateSingleEmail(
          new EmailAddress(_config["MailService:Receiver"]),
          new EmailAddress(_config["MailService:Receiver"]),
          $"Wildermuth.com Site Mail",
          formattedMessage,
          formattedMessage);

        _logger.LogInformation("Attempting to send mail via SendGrid");
        var response = await client.SendEmailAsync(mailMsg);
        _logger.LogInformation("Received response from SendGrid");

        if (response.StatusCode >= System.Net.HttpStatusCode.PartialContent) // Not 200 or 202
        {
          var result = await response.Body.ReadAsStringAsync();
          _logger.LogError($"Failed to send message via SendGrid: Status Code: {response.StatusCode}");
        }
        else
        {
          return true;
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Exception Thrown sending message via SendGrid", ex);
      }
      return false;
    }
  }
}