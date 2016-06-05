using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace WilderBlog.Services.DataProviders
{
  public abstract class DataProvider<T>
  {
    protected string _path;

    public DataProvider(IHostingEnvironment env, string path)
    {
      _path = Path.Combine(env.ContentRootPath, $@"Data\{path}");
    }

    public virtual IEnumerable<T> Get()
    {
      var json = File.ReadAllText(_path);
      return JsonConvert.DeserializeObject<List<T>>(json);
    }

  }
}