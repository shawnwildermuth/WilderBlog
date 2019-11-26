using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilderBlog.Models
{
  public class AdDateRange
  {
    public AdDateRange(string startDate, string endDate, params string[] ads)
    {
      if (!DateTime.TryParse(startDate, out Start) || !DateTime.TryParse(endDate, out End) || ads == null || ads.Length == 0)
      {
        throw new InvalidOperationException("Invalid Ads");
      }
      Ads = ads;
    }

    public readonly DateTime Start;
    public readonly DateTime End;
    public readonly string[] Ads;
  }
}
