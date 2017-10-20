using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WilderBlog.Services
{
  public class MailService : IMailService
  {
    private IConfiguration _config;
    private IHostingEnvironment _env;
    private ILogger<MailService> _logger;

    public MailService(IHostingEnvironment env, IConfiguration config, ILogger<MailService> logger)
    {
      _env = env;
      _config = config;
      _logger = logger;
    }

    public async Task SendMail(string template, string name, string email, string subject, string msg)
    {
      try
      {
        var path = $"{_env.ContentRootPath}\\EmailTemplates\\{template}";
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

        var response = await client.SendEmailAsync(mailMsg);

        if (response.StatusCode >= System.Net.HttpStatusCode.PartialContent) // Not 200 or 202
        {
          var result = await response.Body.ReadAsStringAsync();
          _logger.LogError($"Failed to send message via SendGrid: {Environment.NewLine}Body: {formattedMessage}{Environment.NewLine}Result: {result}");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Exception Thrown sending message via SendGrid", ex);
      }
    }
  }
}