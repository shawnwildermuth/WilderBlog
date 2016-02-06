using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Data
{
  public class WilderBlogRepository
  {
    const string DBID = "WilderBlogStories";
    const string STORYCOLLECTIONID = "Stories";

    private DocumentClient _client = null;
    private IConfigurationRoot _config = null;
    private Database _database = null;
    private DocumentCollection _storyCollection;

    private string DatabaseLink => $"/dbs/{DBID}/";
    private string StoryCollectionLink => $"{DatabaseLink}{STORYCOLLECTIONID}";

    public WilderBlogRepository(IConfigurationRoot config)
    {
      _config = config;
      _client = new DocumentClient(new Uri(_config["WilderDb:EndPoint"]), _config["WilderDb:DbKey"]);
    }

    private async Task EnsureStoryCollectionAsync()
    {
      await EnsureDatabaseAsync();
      var coll = _client.CreateDocumentCollectionQuery(DatabaseLink)
        .Where(s => s.Id == STORYCOLLECTIONID)
        .AsEnumerable()
        .FirstOrDefault();

      if (coll == null)
      {
        _storyCollection = await _client.CreateDocumentCollectionAsync(_database.CollectionsLink, new DocumentCollection() { Id = STORYCOLLECTIONID });
      }
    }

    private async Task EnsureDatabaseAsync()
    {
      if (_database == null)
      {
        var db = _client.CreateDatabaseQuery()
          .Where(d => d.Id == DBID)
          .AsEnumerable()
          .FirstOrDefault();

        // If the database does not exist, create a new database
        if (db == null)
        {
          var result = await _client.CreateDatabaseAsync(new Database() { Id = DBID });
          _database = result;
        }
        else
        {
          _database = db;
        }
      }
    }

    public async Task ClearDatabaseAsync()
    {
      var db = _client.CreateDatabaseQuery()
        .Where(d => d.Id == DBID)
        .AsEnumerable()
        .FirstOrDefault();

      // If the database does not exist, create a new database
      if (db != null)
      {
        await _client.DeleteDatabaseAsync(DatabaseLink);
        _database = null;
      }
    }

    public async Task<bool> AddStory(BlogStory story)
    {
      await EnsureDatabaseAsync();
      await EnsureStoryCollectionAsync();

      var response = await _client.CreateDocumentAsync(_storyCollection.DocumentsLink, story);

      return response.StatusCode == HttpStatusCode.Created;
    }

  }
}
