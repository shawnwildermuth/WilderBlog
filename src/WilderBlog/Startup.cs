using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
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

    public Startup(IHostingEnvironment env)
    {
      _env = env;

      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("config.json", false, true)
        .AddEnvironmentVariables();

      _config = builder.Build();
    }

    public void ConfigureServices(IServiceCollection svcs)
    {
      svcs.AddSingleton(_config);

      if (_env.IsDevelopment())
      {
        svcs.AddTransient<IMailService, LoggingMailService>();
      }
      else
      {
        svcs.AddTransient<IMailService, MailService>();
      }

      svcs.AddDbContext<WilderContext>(ServiceLifetime.Scoped);

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

      svcs.AddTransient<WilderInitializer>();
      svcs.AddScoped<AdService>();

      // Data Providers (non-EF)
      svcs.AddScoped<CalendarProvider>();
      svcs.AddScoped<CoursesProvider>();
      svcs.AddScoped<PublicationsProvider>();
      svcs.AddScoped<PodcastEpisodesProvider>();
      svcs.AddScoped<VideosProvider>();
      svcs.AddTransient<ApplicationEnvironment>();

      // Supporting Live Writer (MetaWeblogAPI)
      svcs.AddMetaWeblog<WilderWeblogProvider>();

      // Add Caching Support
      svcs.AddMemoryCache();

      // Add MVC to the container
      var mvcBuilder = svcs.AddMvc();
      mvcBuilder.AddJsonOptions(opts => opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

      // Add Https - renable once Azure Certs work
      //if (_env.IsProduction()) mvcBuilder.AddMvcOptions(options => options.Filters.Add(new RequireHttpsAttribute()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          ILoggerFactory loggerFactory,
                          IMailService mailService,
                          IServiceScopeFactory scopeFactory)
    {

      // Add the following to the request pipeline only in development environment.
      if (_env.IsDevelopment())
      {
        loggerFactory.AddDebug(LogLevel.Information);
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        // Support logging to email
        loggerFactory.AddEmail(mailService, LogLevel.Critical);
        loggerFactory.AddConsole(LogLevel.Error);

        // Early so we can catch the StatusCode error
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Exception");
      }

      // Rewrite old URLs to new URLs
      app.UseUrlRewriter();

      app.UseStaticFiles();

      // Support MetaWeblog API
      app.UseMetaWeblog("/livewriter");

      app.UseIdentity();

      app.UseMvc();

      if (_config["WilderDb:TestData"] != "True")
      {
        using (var scope = scopeFactory.CreateScope())
        {
          var initializer = scope.ServiceProvider.GetService<WilderInitializer>();
          initializer.SeedAsync().Wait();
        }
      }
    }
  }
}
