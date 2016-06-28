using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WilderBlog.Data
{
  public class WilderInitializer
  {
    private WilderContext _ctx;
    private UserManager<WilderUser> _userMgr;

    public WilderInitializer(WilderContext ctx, UserManager<WilderUser> userMgr)
    {
      _ctx = ctx;
      _userMgr = userMgr;
    }

    public async Task SeedAsync()
    {
      // Seed User
      if (await _userMgr.FindByNameAsync("shawnwildermuth") == null)
      {
        var user = new WilderUser()
        {
          Email = "shawn@wildermuth.com",
          UserName = "shawnwildermuth",
          EmailConfirmed = true
        };

        var result = await _userMgr.CreateAsync(user, "P@ssw0rd!"); // Temp Password
        if (!result.Succeeded) throw new InvalidProgramException("Failed to create seed user");
      }
    }
  }
}
