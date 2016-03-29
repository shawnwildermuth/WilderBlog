using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;

namespace WilderBlog.Services
{
  public class CoursesProvider
  {
    private string _basePath;

    public CoursesProvider(IApplicationEnvironment env)
    {
      _basePath = env.ApplicationBasePath;
    }

    public IEnumerable<Course> Get()
    {
      var json = File.ReadAllText(Path.Combine(_basePath, @"Data\courses.json"));
      return JsonConvert.DeserializeObject<List<Course>>(json);
    }
  }

  public class Course
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Hint { get; set; }
  }
}
