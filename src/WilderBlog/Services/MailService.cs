using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WilderBlog.Services
{
  public class MailService : IMailService
  {
    private IConfigurationRoot _config;
    private IHostingEnvironment _env;
    private ILogger<MailService> _logger;

    public MailService(IHostingEnvironment env, IConfigurationRoot config, ILogger<MailService> logger)
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

        var uri = $"https://api.sendgrid.com/api/mail.send.json";
        var post = new KeyValuePair<string, string>[]
              {
                new KeyValuePair<string, string>("api_user", _config["MailService:ApiUser"]),
                new KeyValuePair<string, string>("api_key", _config["MailService:ApiKey"]),
                new KeyValuePair<string, string>("to", _config["MailService:Receiver"]),
                new KeyValuePair<string, string>("toname", name),
                new KeyValuePair<string, string>("subject", $"Wildermuth.com Site Mail"),
                new KeyValuePair<string, string>("text", string.Format(body, email, name, subject, msg)),
                new KeyValuePair<string, string>("from", _config["MailService:Receiver"])
              };

        var client = new HttpClient();
        var response = await client.PostAsync(uri, new FormUrlEncodedContent(post));
        if (!response.IsSuccessStatusCode)
        {
          var result = await response.Content.ReadAsStringAsync();
          _logger.LogError($"Failed to send message via SendGrid: {Environment.NewLine}Body: {post}{Environment.NewLine}Result: {result}");
        }
      }
      catch (Exception ex)
      {
        _logger.LogError("Exception Thrown sending message via SendGrid", ex);
      }
    }
  }
}