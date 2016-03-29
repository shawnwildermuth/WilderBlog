using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;

namespace WilderBlog.Services.DataProviders
{
  public class AppearancesProvider : DataProvider<Appearance>
  {
    public AppearancesProvider(IApplicationEnvironment env)
      : base(env, "appearances.json")
    {
    }

    public override IEnumerable<Appearance> Get()
    {
      return base.Get().OrderBy(a => a.EventDate).ToList();
    }
  }

  public class Appearance
  {
    public string Name { get; set; }
    public DateTime EventDate { get; set; }
    public int Length { get; set; }
    public string Url { get; set; }
    public string Location { get; set; }
    public string Comment { get; set; }

    public string FormattedDate
    {
      get
      {
        if (Length > 1)
        {
          var endDate = EventDate.AddDays(Length - 1);
          if (endDate.Month == EventDate.Month)
          {
            return string.Format("{0} {1}-{2}, {3}", EventDate.ToString("MMM"), EventDate.Day, endDate.Day, EventDate.Year);
          }
          else
          {
            if (endDate.Year == EventDate.Year)
            {
              return string.Format("{0} {2}-{1} {3}, {4}", EventDate.ToString("MMM"), endDate.ToString("MMM"), EventDate.Day, endDate.Day, EventDate.Year);
            }
            else
            {
              return string.Format("{0}-{1}", EventDate.ToString("MMM d, YYYY"), endDate.ToString("MMM d, YYYY"));
            }
          }
        }
        else
        {
          return EventDate.ToString("MMM d, yyyy");
        }
      }
    }
  }
}
