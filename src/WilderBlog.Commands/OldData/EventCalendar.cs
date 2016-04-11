using System;
using System.Collections.Generic;
using System.Linq;

namespace WilderBlog.OldData
{
  public static class EventCalendar
  {
    private static List<EventCalendarEntry> _list = null;
    public static List<EventCalendarEntry> Events
    {
      get
      {
        if (_list == null)
        {
          BuildList();
        }

        return _list;
      }
    }

    private static void BuildList()
    {
      _list = new List<EventCalendarEntry>()
      {
        new EventCalendarEntry("AngleBrackets/DevIntersection", "2015-10-26", 4, "https://www.anglebrackets.org", "Las Vegas, NV", "Use code 'Wildermuth' for a discount!"),
        new EventCalendarEntry("Code Camp NYC", "2015-10-10", 1, "http://www.codecampnyc.org/", "New York, NY"),
        new EventCalendarEntry("MVP Summit", "2015-11-02", 4, "https://www.mvpnov15.com/", "Seattle, WA"),
        new EventCalendarEntry("Technorama", "2016-05-03", 2, "http://www.techorama.be/", "Belgium"),
        new EventCalendarEntry("Atlanta Code Camp", "2015-10-24", 1, "http://atlantacodecamp.com/", "Atlanta, GA"),
        new EventCalendarEntry("Atlanta Cloud Saturday", "2015-9-26", 1, "http://atlanta.cloudsaturday.com/", "Atlanta, GA"),

        new EventCalendarEntry("Hello World Road Trip", "2016-5-5", 1, "http://hwroadtrip.com/city/brussels", "Brussels, Belgium"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-9", 1, "http://hwroadtrip.com/city/paris", "Paris, France"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-12", 1, "http://hwroadtrip.com/city/barcelona", "Barcelona, Spain"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-19", 1, "http://hwroadtrip.com/city/washington", "Washington, DC"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-23", 1, "http://hwroadtrip.com/city/philadephia", "Philadephia, PA"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-26", 1, "http://hwroadtrip.com/city/new-york-city", "New York City, NY"),
        new EventCalendarEntry("Hello World Road Trip", "2016-5-31", 1, "http://hwroadtrip.com/city/boston", "Boston, MA"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-2", 1, "http://hwroadtrip.com/city/burlington", "Burlington, VT"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-6", 1, "http://hwroadtrip.com/city/montreal", "Montreal, QC"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-9", 1, "http://hwroadtrip.com/city/toronto", "Toronto, ON"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-13", 1, "http://hwroadtrip.com/city/detroit", "Detroit, MI"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-15", 1, "http://hwroadtrip.com/city/chicago", "Chicago, IL"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-20", 1, "http://hwroadtrip.com/city/st-louis", "St. Louis, MO"),
        new EventCalendarEntry("Hello World Road Trip", "2016-6-22", 1, "http://hwroadtrip.com/city/denver", "Denver, CO"),
        //new EventCalendarEntry("Hello World Road Trip", "2016-6-27", 1, "http://hwroadtrip.com/city/portland", "Portland, OR"),
      }.OrderBy(e => e.EventDate)
      .Where(e => e.EventDate > DateTime.Today.AddDays(-5))
      .ToList();
    }
  }

  public class EventCalendarEntry
  {
    public EventCalendarEntry(string name, string date, int length, string link, string location, string note = "")
    {
      EventName = name;
      EventDate = DateTime.Parse(date);
      Link = link;
      Location = location;
      Note = note;
      Length = length > 0 ? length : 1;
    }

    public string EventName { get; private set; }
    public DateTime EventDate { get; private set; }
    public string Link { get; private set; }
    public string Location { get; private set; }
    public string Note { get; private set; }
    public int Length { get; private set; }

    public string FormattedEventDate
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