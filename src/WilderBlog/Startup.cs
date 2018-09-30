using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
    private readonly IConfiguration _config;
    private readonly IHostingEnvironment _env;

    public Startup(IConfiguration config, IHostingEnvironment env)
    {
      _config = config;
      _env = env;
    }

    public void ConfigureServices(IServiceCollection svcs)
    {
      //if (_env.IsDevelopment())
      //{
      //  svcs.AddTransient<IMailService, LoggingMailService>();
      //}
      //else
      //{
        svcs.AddTransient<IMailService, MailService>();
      //}
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
      var mvcBuilder = svcs.AddMvc();
      mvcBuilder.AddJsonOptions(opts => opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
      mvcBuilder.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      // Add Https - renable once Azure Certs work
      if (_env.IsProduction())
      {
        mvcBuilder.AddMvcOptions(options => options.Filters.Add(new RequireHttpsAttribute()));
      }
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
        app.UseDeveloperExceptionPage();
      }
      else
      {
        // Early so we can catch the StatusCode error
        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        app.UseExceptionHandler("/Exception");

        // Support logging to email
        loggerFactory.AddEmail(mailService, LogLevel.Critical);
      }

      // Rewrite old URLs to new URLs
      app.UseUrlRewriter();

      app.UseStaticFiles();

      // Support MetaWeblog API
      app.UseMetaWeblog("/livewriter");

      // Keep track of Active # of users for Vanity Project
      app.UseMiddleware<ActiveUsersMiddleware>();

      // Email Uncaught Exceptions
      if (_config["Exceptions:TestEmailExceptions"].ToLower() == "true" || !_env.IsDevelopment())
      {
        app.UseMiddleware<EmailExceptionMiddleware>();
      }

      app.UseAuthentication();

      app.UseMvc();

      
    }

  }
}
