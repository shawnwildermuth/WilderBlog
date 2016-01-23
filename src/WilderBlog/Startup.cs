using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using WilderBlog.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Diagnostics.Entity;

namespace WilderBlog
{
  public class Startup
  {
    private IConfigurationRoot _config;

    public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(appEnv.ApplicationBasePath)
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();

      _config = builder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddEntityFramework()
        .AddSqlServer()
        .AddDbContext<WilderContext>(options =>
          options.UseSqlServer(_config["Db:TheConnection"]));

      services.AddIdentity<WilderUser, IdentityRole>()
          .AddEntityFrameworkStores<WilderContext>();

      services.AddTransient<IWilderRepository, WilderRepository>();
      services.AddTransient<WilderBlogDatabaseInitializer>();

      services.AddMvc()
        .AddJsonOptions(opts =>
        {
          opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app,
                          IHostingEnvironment env,
                          WilderBlogDatabaseInitializer dbInit)
    {
      app.UseStatusCodePagesWithReExecute("/Error/{0}");

      // Add the following to the request pipeline only in development environment.
      if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
      {
        //app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage(options => options.ShowExceptionDetails = true);
      }
      else
      {
        // Add Error handling middleware which catches all application specific errors and
        // send the request to the following path or controller action.
        app.UseExceptionHandler("/Error");
      }

      app.UseIISPlatformHandler();
      app.UseStaticFiles();

      app.UseIdentity();
      app.UseMvc();

      dbInit.InitializeAsync().Wait();
    }

    // Entry point for the application.
    public static void Main(string[] args) => WebApplication.Run<Startup>(args);
  }
}
