using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WilderBlog.Services
{
  public class EmailExceptionMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IMailService _mailService;

    public EmailExceptionMiddleware(RequestDelegate next, IMailService mailService)
    {
      _next = next;
      _mailService = mailService;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next.Invoke(context);
      }
      catch (Exception ex)
      {
        await _mailService.SendMailAsync("exceptionmessage.txt", "Shawn Wildermuth", "shawn@wildermuth.com", "[WilderBlog Exception]", ex.ToString());

        // Don't swallow the exception
        throw;
      }

    }
  }
}
