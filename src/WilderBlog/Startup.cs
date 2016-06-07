using Glimpse;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using WilderBlog.Data;
using WilderBlog.Logger;
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

      // Add Caching Support
      svcs.AddCaching();

      if (_env.IsDevelopment())
      {
        svcs.AddGlimpse();
      }

      // Add MVC to the container
      var mvcBuilder = svcs.AddMvc();
      mvcBuilder.AddJsonOptions(opts => opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

      // Add Https - renable once Azure Certs work
      if (_env.IsProduction()) mvcBuilder.AddMvcOptions(options => options.Filters.Add(new RequireHttpsAttribute()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          ILoggerFactory loggerFactory,
                          WilderInitializer initializer,
                          IMailService mailService)
    {

      // Add the following to the request pipeline only in development environment.
      if (_env.IsDevelopment())
      {
        loggerFactory.AddDebug(LogLevel.Information);
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage(options => options.ShowExceptionDetails = true);

        // Support Glimpse on the site
        app.UseGlimpse();

      }
      else
      {
        // Support logging to email
        loggerFactory.AddEmail(mailService, LogLevel.Critical);

        // Early so we can catch the StatusCode error
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Exception");
      }

      // Rewrite old URLs to new URLs
      app.UseUrlRewriter();

      app.UseIISPlatformHandler();
      app.UseStaticFiles();

      // Support showing Runtime info
      app.UseRuntimeInfoPage(new RuntimeInfoPageOptions()
      {
        Path = "/siteinfo"
      });

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
