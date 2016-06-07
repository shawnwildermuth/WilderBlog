using System;
using System.Collections.Generic;
using System.Linq;

namespace WilderBlog.Data
{
  public class MemoryRepository : BaseRepository, IWilderRepository
  {
    public void AddStory(BlogStory story)
    {
      story.Id = _stories.Max(s => s.Id) + 1;
      _stories.Add(story);
    }

    public bool DeleteStory(string postid)
    {
      var story = GetStory(int.Parse(postid));
      if (story != null)
      {
        _stories.Remove(story);
      }

      return story != null;
    }

    public IEnumerable<string> GetCategories()
    {
      var cats = _stories
                .Select(c => c.Categories.Split(','))
                .ToList();

      var result = new List<string>();
      foreach (var s in cats) result.AddRange(s);

      return result.Where(s => !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).Distinct();
    }

    public BlogResult GetStories(int pageSize = 10, int page = 1)
    {
      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = _stories.Count(),
        TotalPages = CalculatePages(_stories.Count(), pageSize),
        Stories = _stories.Skip((page - 1) * pageSize).Take(pageSize),
      };
    }

    public BlogResult GetStoriesByTerm(string term, int pageSize, int page)
    {
      var lowerTerm = term.ToLowerInvariant();
      var totalCount = _stories.Where(s =>
          s.Body.ToLowerInvariant().Contains(lowerTerm) ||
          s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
          s.Title.ToLowerInvariant().Contains(lowerTerm)
          ).Count();

      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _stories
        .Where(s =>
        {
          return s.Body.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
                 s.Title.ToLowerInvariant().Contains(lowerTerm);
        })
        .Skip((page - 1) * pageSize).Take(pageSize)
      };
    }

    public BlogStory GetStory(string slug)
    {
      return _stories.Where(s => s.Slug == slug).FirstOrDefault();
    }

    public BlogStory GetStory(int id)
    {
      return _stories.Where(s => s.Id == id).FirstOrDefault();
    }

    public void SaveAll()
    {
      // NOOP
    }

    public BlogResult GetStoriesByTag(string tag, int pageSize, int page)
    {
      var lowerTag = tag.ToLowerInvariant();
      var totalCount = _stories.Where(s => s.Categories.ToLowerInvariant().Split(',').Contains(lowerTag)).Count();

      return new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _stories
        .Where(s => s.Categories.ToLowerInvariant().Split(',').Contains(lowerTag))
        .Skip((page - 1) * pageSize).Take(pageSize)
      };
    }

    static List<BlogStory> _stories = new List<BlogStory>()
    {
      new BlogStory()
      {
        Id = 1,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><img style=""float: right; display: inline"" src=""http://hwroadtrip.com/img/logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      },
      new BlogStory()
      {
        Id = 2,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://wildermuth.com/images/8931dc63-9e1e-491a-a64a-3a0eb4a67101..png""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""http://wildermuth.com/images/8280574b-0c91-478f-8340-d3bcaa40ab76..png"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre>c:/>dnx web</pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 3,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""http://wildermuth.com/images/DevIntersection_3.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
    };
  }
}
