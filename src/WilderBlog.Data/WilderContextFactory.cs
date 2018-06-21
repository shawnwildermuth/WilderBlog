using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderContextFactory : IDesignTimeDbContextFactory<WilderContext>
  {
    public WilderContext CreateDbContext(string[] args)
    {
      // Create a configuration 
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("config.json")
        .Build();

      return new WilderContext(new DbContextOptionsBuilder<WilderContext>().Options, config);
    }
  }
}
