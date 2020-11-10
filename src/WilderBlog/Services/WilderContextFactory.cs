using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WilderBlog.Data;

namespace WilderBlog.Services
{
  public class WilderContextFactory : IDesignTimeDbContextFactory<WilderContext>
  {
    public WilderContext CreateDbContext(string[] args)
    {
      // Create a configuration 
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("config.json")
        .AddEnvironmentVariables()
        .Build();

      return new WilderContext(new DbContextOptionsBuilder<WilderContext>().Options, config);
    }
  }
}
