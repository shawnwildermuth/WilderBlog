using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using WilderBlog.Data;
using WilderBlog.MetaWeblog;
using WilderBlog.Services;
using WilderBlog.Services.DataProviders;
using WilderMinds.MetaWeblog;

namespace WilderBlog
{
  public class Startup
  {
    private IConfigurationRoot _config;
    private IHostingEnvironment _env;

    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
      _env = env;

      var builder = new ConfigurationBuilder()
        .SetBasePath(appEnv.ApplicationBasePath)
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();

      _config = builder.Build();
    }

    public void ConfigureServices(IServiceCollection svcs)
    {
      svcs.AddInstance(_config);

      if (_env.IsDevelopment())
      {
        svcs.AddTransient<IMailService, LoggingMailService>();
      }
      else
      {
        svcs.AddTransient<IMailService, MailService>();
      }

      svcs.AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<WilderContext>();

      svcs.AddIdentity<WilderUser, IdentityRole>()
        .AddEntityFrameworkStores<WilderContext>();

      if (_config["WilderDb:TestData"] == "True")
      {
        svcs.AddScoped<IWilderRepository, MemoryRepository>();
      }
      else
      {
        svcs.AddScoped<IWilderRepository, WilderRepository>();
      }

      svcs.AddScoped<WilderInitializer>();
      svcs.AddScoped<AdService>();

      // Data Providers (non-EF)
      svcs.AddScoped<CalendarProvider>();
      svcs.AddScoped<CoursesProvider>();
      svcs.AddScoped<PublicationsProvider>();
      svcs.AddScoped<PodcastEpisodesProvider>();
      svcs.AddScoped<VideosProvider>();

      // Supporting Live Writer (MetaWeblogAPI)
      svcs.AddMetaWeblog<WilderWeblogProvider>();

      // Add MVC to the container
      svcs.AddMvc()
        .AddJsonOptions(opts =>
        {
          opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          ILoggerFactory loggerFactory,
                          WilderInitializer initializer)
    {

      if (_env.IsProduction())
      {
        // Early so we can catch the StatusCode error
        app.UseExceptionHandler("/Error/{0}");
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
      }

      app.UseUrlRewriter();

      // Add the following to the request pipeline only in development environment.
      if (_env.IsDevelopment())
      {
        loggerFactory.AddDebug(LogLevel.Information);
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage(options => options.ShowExceptionDetails = true);
      }
      else
      {
        // Add Error handling middleware which catches all application specific errors and
        // send the request to the following path or controller action.
        loggerFactory.AddDebug(LogLevel.Error);
        app.UseExceptionHandler("/Error");
      }

      app.UseIISPlatformHandler();
      app.UseStaticFiles();

      // Support MetaWeblog API
      app.UseMetaWeblog("/livewriter");

      app.UseIdentity();

      app.UseMvc();

      if (_config["WilderDb:TestData"] != "True")
      {
        initializer.SeedAsync().Wait();
      }
    }

    // Entry point for the application.
    public static void Main(string[] args) => WebApplication.Run<Startup>(args);
  }
}
