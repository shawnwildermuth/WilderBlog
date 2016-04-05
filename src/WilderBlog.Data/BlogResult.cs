using System.Collections.Generic;

namespace WilderBlog.Data
{
  public class BlogResult
  {
    public IEnumerable<BlogStory> Stories;
    public int TotalResults;
    public int TotalPages;
    public int CurrentPage;
  }
}