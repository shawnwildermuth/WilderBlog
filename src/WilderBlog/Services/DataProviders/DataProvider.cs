using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;

namespace WilderBlog.Services.DataProviders
{
  public abstract class DataProvider<T>
  {
    protected string _path;

    public DataProvider(IApplicationEnvironment env, string path)
    {
      _path = Path.Combine(env.ApplicationBasePath, $@"Data\{path}");
    }

    public virtual IEnumerable<T> Get()
    {
      var json = File.ReadAllText(_path);
      return JsonConvert.DeserializeObject<List<T>>(json);
    }

  }
}