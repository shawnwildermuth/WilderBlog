using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WilderBlog.Services;

namespace WilderBlog.Controllers.Api
{
  public class ActiveUsersController : Controller
  {
    private IMemoryCache _cache;

    public ActiveUsersController(IMemoryCache cache)
    {
      _cache = cache;
    }

    [HttpGet("/api/active/users")]
    public IActionResult Get()
    {
      try
      {
        var users = ActiveUsersMiddleware.GetActiveUserCount(_cache);
        return Ok(new { ActiveUsers = users, Message = $"{users} active on the site" });
      }
      catch (Exception ex)
      {
        return Ok(new { ActiveUsers = 0, Message = $"Exception Thrown during process: {ex.Message}" });
      }
    }
  }
}
