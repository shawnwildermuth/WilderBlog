using System;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WilderBlog.MetaWeblog
{
  public static class MetaWeblogExtensions
  {
    public static IApplicationBuilder UseMetaWeblog(this IApplicationBuilder builder, string path)
    {
      return builder.UseMiddleware<MetaWeblogMiddleware>(path);
    }

    public static IServiceCollection AddMetaWeblog(this IServiceCollection coll)
    {
      return coll.AddScoped<MetaWeblogProcessor>();
    }
  }
}
