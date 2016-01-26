using System.Threading.Tasks;

namespace WilderBlog.Services
{
  public interface IMailService
  {
    Task SendMail(string template, string name, string email, string subject, string msg);
  }
}