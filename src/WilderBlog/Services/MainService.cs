using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using SendGrid;

namespace WilderBlog.Services
{
  public class MailService : IMailService
  {
    private IConfigurationRoot _config;
    private IApplicationEnvironment _env;

    public MailService(IApplicationEnvironment env, IConfigurationRoot config)
    {
      _env = env;
      _config = config;
    }

    public async Task SendMail(string template, string name, string email, string subject, string msg)
    {
      var path = $"{_env.ApplicationBasePath}\\EmailTemplates\\{template}";
      var body = File.ReadAllText(path);

      var emailMsg = new SendGridMessage();
      emailMsg.AddTo(_config["MailService:Sender"]);
      emailMsg.From = new MailAddress(_config["MailService:Sender"]);
      emailMsg.Subject = subject;
      emailMsg.Text = body;

      var client = new Web(_config["MailService:ApiKey"]);
      await client.DeliverAsync(emailMsg);
    }
  }
}