using System.ComponentModel.DataAnnotations;

namespace WilderBlog.Models
{
  public class ContactModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [MaxLength(4096)]
    [MinLength(5)]
    public string Msg { get; set; } = "";
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string Subject { get; set; } = "";
    public string Recaptcha { get; set; } = "";
    public string Phone { get; set; } = "";
  }
}