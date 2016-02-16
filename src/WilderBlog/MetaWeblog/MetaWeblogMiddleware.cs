using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using XmlRpcLight;

namespace WilderBlog.MetaWeblog
{
  public class MetaWeblogMiddleware
  {
    private ILogger _logger;
    private readonly RequestDelegate _next;
    private MetaWeblogProcessor _processor;
    private string _urlEndpoint;

    public MetaWeblogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, string urlEndpoint, MetaWeblogProcessor processor)
    {
      _next = next;
      _logger = loggerFactory.CreateLogger<MetaWeblogMiddleware>(); ;
      _urlEndpoint = urlEndpoint;
      _processor = processor;
    }

    public async Task Invoke(HttpContext context)
    {
      if (context.Request.Method == "POST" &&
        context.Request.Path.StartsWithSegments(_urlEndpoint) && 
        context.Request != null && 
        context.Request.ContentType.ToLower().Contains("text/xml"))
      {
        var rdr = new StreamReader(context.Request.Body);
        var xml = rdr.ReadToEnd();
        var result = _processor.Invoke(xml);
        await context.Response.WriteAsync(result, Encoding.UTF8);
        context.Response.ContentType = "text/xml";
      }

      // Continue On
      await _next.Invoke(context);
    }
  }
}
