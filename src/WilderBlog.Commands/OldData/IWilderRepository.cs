using System.Collections.Generic;

namespace WilderBlog.OldData
{
  public interface IWilderRepository
  {
    IEnumerable<Story> GetNewStories();
  }
}