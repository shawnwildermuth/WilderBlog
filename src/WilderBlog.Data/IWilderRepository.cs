using System;
using System.Collections.Generic;

namespace WilderBlog.Data
{
  public interface IWilderRepository
  {
    // Story
    IEnumerable<BlogStory> GetStories(int count = 10, int page = 0);
    BlogStory GetStory(int id);
    BlogStory GetStory(string slug);
    void AddStory(BlogStory story);

    void SaveAll();
    bool DeleteStory(string postid);

    IEnumerable<string> GetCategories();
  }
}