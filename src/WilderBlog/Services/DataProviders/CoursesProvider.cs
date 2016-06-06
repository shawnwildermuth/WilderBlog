using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;

namespace WilderBlog.Services.DataProviders
{
  public class CoursesProvider : DataProvider<Course>
  {
  
    public CoursesProvider(IApplicationEnvironment env)
      : base(env, "courses.json")
    {
    }
  }

  public class Course
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Hint { get; set; }
  }
}
