using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WilderBlog.Data;

namespace WilderBlog
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigureConfiguration)
            .UseStartup<Startup>()
            .Build();

      Seed(host).Wait();

      host.Run();
    }

    private static async Task Seed(IWebHost host)
    {
      IConfiguration config = (IConfiguration)host.Services.GetService(typeof(IConfiguration));
      if (config["WilderDb:TestData"] != "True")
      {
        IServiceScopeFactory scopeFactory = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
        using (var scope = scopeFactory.CreateScope())
        {
          var initializer = scope.ServiceProvider.GetService<WilderInitializer>();
          await initializer.SeedAsync();
        }
      }
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
