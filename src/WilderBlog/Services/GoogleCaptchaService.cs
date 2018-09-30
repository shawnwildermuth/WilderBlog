using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WilderBlog.Models;

namespace WilderBlog.Services
{
  public class GoogleCaptchaService
  {
    private readonly ILogger<GoogleCaptchaService> _logger;
    private readonly IConfiguration _config;
    private readonly IHttpContextAccessor _ctxAccessor;

    public GoogleCaptchaService(ILogger<GoogleCaptchaService> logger, IConfiguration config, IHttpContextAccessor ctxAccessor)
    {
      _logger = logger;
      _config = config;
      _ctxAccessor = ctxAccessor;
    }

    public async Task<bool> Verify(string recaptcha)
    {
      var uri = "https://www.google.com/recaptcha/api/siteverify";
      var request = _ctxAccessor.HttpContext.Request;

      //make the api call and determine validity
      using (var client = new HttpClient())
      {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("secret", _config["Google:CaptchaSecret"]),
            new KeyValuePair<string, string>("response", recaptcha),
            new KeyValuePair<string, string>("remoteip", request.Headers.ContainsKey("HTTP_X_FORWARDED_FOR") ?
                                                          request.Headers["HTTP_X_FORWARDED_FOR"].FirstOrDefault() :
                                                          _ctxAccessor.HttpContext.Connection.RemoteIpAddress.ToString())

        });

        var result = await client.PostAsync(uri, content);

        if (result.IsSuccessStatusCode)
        {
          var json = await result.Content.ReadAsStringAsync();
          var verifyResponse = JsonConvert.DeserializeObject<SiteVerifyResult>(json);
          if (verifyResponse.Success)
          {
            return true;
          }
        }

      }

      return false;
    }
  }
}
