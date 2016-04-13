using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using WilderBlog.Data;

namespace WilderBlog.Controllers
{
  [Route("[controller]")]
  public class AdminController : Controller
  {
    private UserManager<WilderUser> _userManager;

    public AdminController(UserManager<WilderUser> userManager)
    {
      _userManager = userManager;
    }

    [Route("changepwd")]
    public async Task<IActionResult> ChangePwd(string username, string oldPwd, string newPwd)
    {
      var user = await _userManager.FindByEmailAsync(username);
      if (user == null) return HttpBadRequest(new { success = false });
      var result = await _userManager.ChangePasswordAsync(user, oldPwd, newPwd);
      if (result.Succeeded) return Ok(new { success = true });
      else return HttpBadRequest(new { success = false, errors = result.Errors });
    }
  }
}
