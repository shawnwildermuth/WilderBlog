using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilderBlog.Data;
using WilderBlog.Helpers;
using Xunit;

namespace WilderBlog.Tests
{
  public class BlogStoryExtensionTests
  {
    BlogStory story = new BlogStory()
    {
      DatePublished = new DateTime(2018, 5, 5),
      Title = "This is a test post",
      Body = @"<p>One</p><p>Two</p><p>Three</p>"
    };

    BlogStory unsafeStory = new BlogStory()
    {
      DatePublished = new DateTime(2018, 5, 5),
      Title = @"Are favorite's part of this title, or is it wierd?",
      Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""http://wildermuth.com/images/DevIntersection_3.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
    };

    [Fact]
    public void TestSafeUrlTitle()
    {
      Assert.Contains("Are-favorite-s-part-of-this-title-or-is-it-wierd", unsafeStory.GetUrlSafeTitle(), StringComparison.CurrentCultureIgnoreCase);
    }

    [Fact]
    public void TestStoryUrl()
    {
      Assert.Contains("2018/05/05/This-is-a-test-post", story.GetStoryUrl(), StringComparison.CurrentCultureIgnoreCase);
      Assert.Contains("Are-favorite-s-part-of-this-title-or-is-it-wierd", unsafeStory.GetStoryUrl(), StringComparison.CurrentCultureIgnoreCase);
      Assert.Contains(story.GetUrlSafeTitle(), story.GetStoryUrl(), StringComparison.CurrentCultureIgnoreCase);
    }

    [Fact]
    public void TestSummary()
    {
      Assert.DoesNotContain("Three", story.GetSummary());
      Assert.DoesNotContain("API Design", unsafeStory.GetSummary());
    }

  }
}
