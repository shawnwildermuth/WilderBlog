using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WilderBlog.Data
{
  // HACK to get Migrations to work.
  public class Startup
  {
    private IConfigurationRoot _config;

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("config.json", false, true)
        .AddEnvironmentVariables();

      _config = builder.Build();

    }

    public void ConfigureServices(IServiceCollection svc)
    {
      svc.AddSingleton<IConfigurationRoot>(_config);

      svc.AddEntityFrameworkSqlServer()
        .AddDbContext<WilderContext>();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseAuthentication();
    }
  }
}
