using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WilderBlog.Data
{
  public interface IWilderRepository
  {
    // Story
    Task<BlogResult> GetStories(int pageSize = 10, int page = 1);
    Task<BlogResult> GetStoriesByTerm(string term, int pageSize, int page);
    Task<BlogResult> GetStoriesByTag(string tag, int pageSize, int page);

    Task<BlogStory> GetStory(int id);
    Task<BlogStory> GetStory(string slug);

    Task<IEnumerable<string>> GetCategories();

    void AddStory(BlogStory story);
    Task<bool> DeleteStory(string postid);
    Task<bool> SaveAllAsync();

  }
}