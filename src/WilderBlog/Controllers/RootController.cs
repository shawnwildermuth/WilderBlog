using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WilderBlog.Data;
using WilderBlog.Models;
using WilderBlog.Services;

namespace WilderBlog.Controllers
{
  [Route("")]
  public class RootController : Controller
  {
    private IMailService _mailService;

    public RootController(IMailService mailService)
    {
      _mailService = mailService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
      return View();
    }

    [HttpPost("contact")]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact([FromBody]ContactModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          await _mailService.SendMail("ContactTemplate.txt", model.Name, model.Email, model.Subject, model.Msg);

          return Ok(new { Success = true, Message = "Message Sent" });
        }
        else
        {
          ModelState.AddModelError("", "Failed to send email");
          return HttpBadRequest(ModelState);
        }
      }
      catch (Exception)
      {
        // TODO
        return HttpBadRequest(new { Reason = "Error Occurred" });
      }

    }
  }
}
