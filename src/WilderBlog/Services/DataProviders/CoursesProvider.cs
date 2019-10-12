using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WilderBlog.Services.DataProviders
{
  public class CoursesProvider : DataProvider<Course>
  {
  
    public CoursesProvider(IHostEnvironment env)
      : base(env, "courses.json")
    {
    }
  }

  public enum CourseType
  {
    Invalid = 0,
    Pluralsight = 1,
    WilderMinds = 2
  }

  public class Course
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Hint { get; set; }
    public CourseType CourseType { get; set; } = CourseType.Pluralsight;
  }
}
