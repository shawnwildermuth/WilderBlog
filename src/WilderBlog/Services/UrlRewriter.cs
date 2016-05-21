using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WilderBlog.Services
{
  public class UrlRewriter
  {
    private RequestDelegate _next;

    public UrlRewriter(RequestDelegate next)
    {
      _next = next;
    }

    IEnumerable<UrlRule> _rules = new List<UrlRule>()
    {
      new UrlRule() { Search = "/images/", Replace = "/img/blog/" }
    };

    public async Task Invoke(HttpContext context)
    {
      foreach (var rule in _rules)
      {
        if (context.Request.Path.Value.Contains(rule.Search))
        {
          context.Request.Path = context.Request.Path.Value.Replace(rule.Search, rule.Replace);
        }
      }

      // Specialized for hwpod
      var ex = new Regex(@"\/hwpod\/([0-9]*)_([a-zA-Z]*)_([a-zA-Z]*)", RegexOptions.IgnoreCase);
      var match = ex.Match(context.Request.Path);
      if (match.Success)
      {
        context.Response.Redirect($"/hwpod/{match.Groups[1]}/{match.Groups[2]}-{match.Groups[3]}", true);
      }
      else
      {
        await _next(context);
      }
    }

  }

  public class UrlRule
  {
    public string Replace { get; internal set; }
    public string Search { get; internal set; }
  }

  public static class UrlRewriterExtensions
  {
    public static IApplicationBuilder UseUrlRewriter(this IApplicationBuilder builder)
    {
      return builder.Use(next => new UrlRewriter(next).Invoke);
    }
  }
}
