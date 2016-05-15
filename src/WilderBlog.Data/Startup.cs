using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace WilderBlog.Data
{
  // HACK to get Migrations to work.
  public class Startup
  {
    private IConfigurationRoot _config;

    public Startup(IApplicationEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ApplicationBasePath)
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();

      _config = builder.Build();

    }

    public void ConfigureServices(IServiceCollection svc)
    {
      svc.AddInstance(_config);

      svc.AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<WilderContext>();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseIdentity();
    }
  }
}
