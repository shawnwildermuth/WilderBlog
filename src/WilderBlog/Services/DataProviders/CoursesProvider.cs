using Microsoft.AspNetCore.Hosting;

namespace WilderBlog.Services.DataProviders
{
  public class CoursesProvider : DataProvider<Course>
  {
  
    public CoursesProvider(IHostingEnvironment env)
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
