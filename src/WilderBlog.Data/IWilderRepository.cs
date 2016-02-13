using System.Collections.Generic;

namespace WilderBlog.Data
{
  public interface IWilderRepository
  {
    void AddStory(BlogStory story);
    IEnumerable<BlogStory> GetStories(int count = 10, int page = 0);
    void SaveAll();
  }
}