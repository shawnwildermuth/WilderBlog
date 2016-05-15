using Microsoft.Extensions.PlatformAbstractions;

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
