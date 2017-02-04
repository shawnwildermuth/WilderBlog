using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace WilderBlog.Services
{
  public class ActiveUsersMiddleware
  {
    public const string CookieName = ".Vanity.WilderBlog";
    private const int TIMEOUTMINUTES = 5;
    private IMemoryCache _cache;
    private RequestDelegate _next;
    private ILogger<ActiveUsersMiddleware> _logger;

    public ActiveUsersMiddleware(RequestDelegate next, IMemoryCache cache, ILogger<ActiveUsersMiddleware> logger)
    {
      _next = next;
      _cache = cache;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        string cookie;
        if (context.Request.Cookies.ContainsKey(CookieName))
        {
          cookie = context.Request.Cookies[CookieName];
        }
        else
        {
          cookie = Guid.NewGuid().ToString();
        }

        var key = $"ActiveUser_{cookie}";
        _cache.Set<object>(key, new object(), TimeSpan.FromMinutes(TIMEOUTMINUTES));
        context.Response.Cookies.Append(CookieName, cookie, new CookieOptions() { Expires = DateTimeOffset.Now.AddMinutes(TIMEOUTMINUTES) });
      }
      catch
      {
        _logger.LogError("Failed to store active user");
      }

      await _next.Invoke(context);
    }

    static IDictionary _dictionary = null;

    public static long GetActiveUserCount(IMemoryCache cache)
    {
      try
      {
        if (_dictionary == null)
        {
          var cacheType = cache.GetType();
          var fieldInfo = cacheType.GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance);
          _dictionary = (IDictionary)fieldInfo.GetValue(cache);
        }

        return _dictionary.Keys.Cast<object>().Count(k => k is string && ((string)k).StartsWith("ActiveUser_"));
      }
      catch
      {
        return 0; // if fails, just punt
      }

    }
    
  }
}
