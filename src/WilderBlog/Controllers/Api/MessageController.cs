using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WilderBlog.Models;
using WilderBlog.Services;

namespace WilderBlog.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  [EnableCors(Startup.CorsPolicyName)]
  public class MessageController : ControllerBase
  {
    private readonly IMailService _mailService;
    private readonly ILogger<MessageController> _logger;

    public MessageController(IMailService mailService, ILogger<MessageController> logger)
    {
      _mailService = mailService;
      _logger = logger;
    }

    public async Task<ActionResult> Post([FromBody] ContactModel model)
    {
      try
      {
        if (await _mailService.SendMailAsync("WilderMindsContact.txt", model.Name, model.Email, model.Subject, model.Msg, model.Phone))
        {
          return Ok(new { Success = true, Message = "Message Sent" });
        }

      }
      catch (Exception ex)
      {
        _logger.LogError("Failed to send email from contact page", ex);
        return BadRequest(new { Reason = "Error Occurred" });
      }

      return BadRequest(new { Reason = "Failed to send email..." });

    }
  }
}
