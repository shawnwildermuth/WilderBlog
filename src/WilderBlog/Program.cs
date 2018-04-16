using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WilderBlog
{
  public class Program
  {
    public static void Main(string[] args)
    {
      WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(ConfigureConfiguration)
        .ConfigureLogging(ConfigureLogging)
        .UseStartup<Startup>()
        .Build()
        .Run();
    }

    private static void ConfigureLogging(ILoggingBuilder bldr)
    {
      bldr.ClearProviders()
        .AddDebug()
        .AddConsole()
        .SetMinimumLevel(LogLevel.Warning);
    }

    private static void ConfigureConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
    {
      // Reset to remove the old configuration sources to give us complete control
      builder.Sources.Clear();

      builder.SetBasePath(ctx.HostingEnvironment.ContentRootPath)
        .AddJsonFile("config.json", false, true)
        .AddEnvironmentVariables();
    }
  }
}
