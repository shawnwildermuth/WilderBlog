using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Services
{
  public class AdService
  {
    private IConfigurationRoot _config;

    public AdService(IConfigurationRoot config)
    {
      _config = config;
    }

    public HtmlString InlineAdd()
    {
      return new HtmlString($@"<div>
  <!-- Inline Links -->
  <ins class=""adsbygoogle""
       style=""display:inline-block;width:468px;height:15px""
       data-ad-client=""{_config["AdService:Client"]}""
       data-ad-slot=""{_config["AdService:Slot"]}""></ins>
</div>");
    }
  }
}
