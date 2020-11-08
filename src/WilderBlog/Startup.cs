using System;
using System.Diagnostics;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using WilderBlog.Config;
using WilderBlog.Data;
using WilderBlog.Helpers;
using WilderBlog.Logger;
using WilderBlog.MetaWeblog;
using WilderBlog.Services;
using WilderBlog.Services.DataProviders;
using WilderMinds.MetaWeblog;

namespace WilderBlog
{
  public class Startup
  {
    private readonly IConfiguration _config;
    private readonly IHostEnvironment _env;

    public Startup(IConfiguration config, IHostEnvironment env)
    {
      _config = config;
      _env = env;
    }

    public void ConfigureServices(IServiceCollection svcs)
    {
      svcs.Configure<AppSettings>(_config);

      if (_env.IsDevelopment() && _config.GetValue<bool>("MailService:TestInDev") == false)
      {
        svcs.AddTransient<IMailService, LoggingMailService>();
      }
      else
      {
        svcs.AddTransient<IMailService, MailService>();
      }
      svcs.AddTransient<GoogleCaptchaService>();

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

      svcs.ConfigureHealthChecks(_config);

      svcs.AddTransient<WilderInitializer>();
      svcs.AddScoped<AdService>();

      // Data Providers (non-EF)
      svcs.AddScoped<CalendarProvider>();
      svcs.AddScoped<CoursesProvider>();
      svcs.AddScoped<PublicationsProvider>();
      svcs.AddScoped<PodcastEpisodesProvider>();
      svcs.AddScoped<VideosProvider>();
      svcs.AddTransient<IImageStorageService, ImageStorageService>();

      // Supporting Live Writer (MetaWeblogAPI)
      svcs.AddMetaWeblog<WilderWeblogProvider>();

      // Add Caching Support
      svcs.AddMemoryCache(opt => opt.ExpirationScanFrequency = TimeSpan.FromMinutes(5));

      // Add MVC to the container
      svcs.AddControllersWithViews();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          ILoggerFactory loggerFactory,
                          IMailService mailService,
                          IServiceScopeFactory scopeFactory,
                          IOptions<AppSettings> settings)
    {
      // Add the following to the request pipeline only in development environment.
      if (_env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // Early so we can catch the StatusCode error
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Exception");

        // Support logging to email
        loggerFactory.AddEmail(mailService, LogLevel.Critical);

        app.UseHttpsRedirection();
      }

      // Support MetaWeblog API
      app.UseMetaWeblog("/livewriter");

      // Rewrite old URLs to new URLs
      app.UseUrlRewriter();

      app.UseStaticFiles();

      // Email Uncaught Exceptions
      if (settings.Value.Exceptions.TestEmailExceptions || !_env.IsDevelopment())
      {
        app.UseMiddleware<EmailExceptionMiddleware>();
      }

      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(cfg =>
      {
        cfg.MapControllers();
        cfg.MapHealthChecks("/hc", new HealthCheckOptions()
        {
          Predicate = _ => true,
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
      });
    }

  }
}
