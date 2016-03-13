using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace WilderBlog.Services
{
  public class MailService : IMailService
  {
    private IConfigurationRoot _config;
    private IApplicationEnvironment _env;
    private ILogger<MailService> _logger;

    public MailService(IApplicationEnvironment env, IConfigurationRoot config, ILogger<MailService> logger)
    {
      _env = env;
      _config = config;
      _logger = logger;
    }

    public async Task SendMail(string template, string name, string email, string subject, string msg)
    {
      try
      {
        var path = $"{_env.ApplicationBasePath}\\EmailTemplates\\{template}";
        var body = File.ReadAllText(path);

        var key = _config["MailService:ApiKey"];

        var uri = $"https://api.sendgrid.com/api/mail.send.json";
        var post = new KeyValuePair<string, string>[]
              {
              new KeyValuePair<string, string>("to", email),
              new KeyValuePair<string, string>("toname", name),
              new KeyValuePair<string, string>("subject", subject),
              new KeyValuePair<string, string>("text", body),
              new KeyValuePair<string, string>("from", _config["MailService:Sender"]),
              };

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "key");
        var response = await client.PostAsync(uri, new FormUrlEncodedContent(post));
        if (!response.IsSuccessStatusCode)
        {
          _logger.LogError("Failed to send message via SendGrid");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Exception Thrown sending message via SendGrid", ex);
      }
    }
  }
}