using System.Collections.Generic;

namespace WilderBlog.Data
{
  public interface IWilderRepository
  {
    IEnumerable<Story> GetNewStories();
  }
}