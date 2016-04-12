using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace WilderBlog.Commands
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Starting WilderBlog Migration");
      Console.WriteLine();

      string command = args == null ? "" : args[0].ToLower();
      new SiteMigration().Run(command);
    }

  }
}
