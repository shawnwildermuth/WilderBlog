using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilderBlog.Models
{
    public class SiteVerifyModel
    {
    public string Secret { get; set; } = "";
    public string Response { get; set; } = "";
    public string RemoteIp { get; set; } = "";
  }
}
