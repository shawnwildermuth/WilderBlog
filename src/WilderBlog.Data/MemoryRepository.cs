using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WilderBlog.Data
{
  public class MemoryRepository : BaseRepository, IWilderRepository
  {
    public void AddStory(BlogStory story)
    {
      story.Id = _stories.Max(s => s.Id) + 1;
      _stories.Add(story);
    }

    public async Task<bool> DeleteStory(string postid)
    {
      var story = await GetStory(int.Parse(postid));
      if (story != null)
      {
        _stories.Remove(story);
      }

      return story != null;
    }

    public Task<IEnumerable<string>> GetCategories()
    {
      var cats = _stories
                .Select(c => c.Categories.Split(','))
                .ToList();

      var result = new List<string>();
      foreach (var s in cats) result.AddRange(s);

      return Task.FromResult(result.Where(s => !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).Distinct());
    }

    public Task<BlogResult> GetStories(int pageSize = 10, int page = 1)
    {
      return Task.FromResult(new BlogResult()
      {
        CurrentPage = page,
        TotalResults = _stories.Count(),
        TotalPages = CalculatePages(_stories.Count(), pageSize),
        Stories = _stories.Skip((page - 1) * pageSize).Take(pageSize),
      });
    }

    public Task<BlogResult> GetStoriesByTerm(string term, int pageSize, int page)
    {
      var lowerTerm = term.ToLowerInvariant();
      var totalCount = _stories.Where(s =>
          s.Body.ToLowerInvariant().Contains(lowerTerm) ||
          s.Categories.ToLowerInvariant().Contains(lowerTerm) ||
          s.Title.ToLowerInvariant().Contains(lowerTerm)
          ).Count();

      return Task.FromResult(new BlogResult()
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
      });
    }

    public Task<BlogStory> GetStory(string slug)
    {
      return Task.FromResult(_stories.Where(s => s.Slug == slug).FirstOrDefault());
    }

    public Task<BlogStory> GetStory(int id)
    {
      return Task.FromResult(_stories.Where(s => s.Id == id).FirstOrDefault());
    }

    public Task<BlogResult> GetStoriesByTag(string tag, int pageSize, int page)
    {
      var lowerTag = tag.ToLowerInvariant();
      var totalCount = _stories.Where(s => s.Categories.ToLowerInvariant().Split(',').Contains(lowerTag)).Count();

      return Task.FromResult(new BlogResult()
      {
        CurrentPage = page,
        TotalResults = totalCount,
        TotalPages = CalculatePages(totalCount, pageSize),
        Stories = _stories
        .Where(s => s.Categories.ToLowerInvariant().Split(',').Contains(lowerTag))
        .Skip((page - 1) * pageSize).Take(pageSize)
      });
    }

    public Task<bool> SaveAllAsync()
    {
      // NOOP
      return Task.FromResult(true);
    }

    public static List<BlogStory> _stories = new List<BlogStory>()
    {
      new BlogStory()
      {
        Id = 1,
        IsPublished = true,
        Title = "Do I Always Need ASP.NET?",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/vue.png",
        Body = @"<p><img src=""/img/ps_logo.png"" class=""w-25 img-fluid float-right img-thumbnail"" alt=""nginx"" /> The last couple of years I've needed a couple of new sites to promote things I'm working. Because I'm a .NET developer, my first instinct is always to just File-&gt;New an ASP.NET site. But should I?</p>
<p>Instead of using ASP.NET, these sites are typically one-pagers to promote something. I've done this with my <a href=""https://helloworldfilm.com"">https://helloworldfilm.com</a>, <a href=""https://imfinefilm.com"">https://imfinefilm.com</a>, and most recently my COVID-19 state-by-state tracking site: <a href=""https://covidstates.azurewebsites.net"">https://covidstates.azurewebsites.net</a>.</p>
<p>The benefit of skipping ASP.NET in these cases is simplicity. They're just HTML/CSS/JS. Since I don't need any server-side code running, I just create the HTML and post it. Even in the cases of the film sites, I use widgets (in my case with MailChimp) to collect emails instead of doing the email work server-side.</p>
<p>It's more about combining services than my own &lsquo;platform&rsquo;. Let me be clear, this is an option, not the way I would implement many websites. But for read-only content, this is a great, simple way to get something up fast.</p>
<h2 id=""during-development"">During Development</h2>
<p>Let's talk about how I'm doing the development first. If you want to reference the code, it's at <a href=""https://github.com/shawnwildermuth/covidstates"">https://github.com/shawnwildermuth/covidstates</a>.</p>
<p>The project structure is pretty simple:</p>
<pre><code class=""lang-command"">CovidStates
 - src
   - index.html
</code></pre>
<p>There are more files there so I can build it and such, but to start out, I just create a simple index.html.</p>
<p>I usually use John Papa's great lite-server (<a href=""https://github.com/johnpapa/lite-server"">link</a>) to use during development. It's as simple as just opening up a console and:</p>
<pre><code>d:\CovidStates\src&gt;lite-server .
</code></pre>
<p>It hosts the source code and uses browser-link so you can just change the code and it will update in the browser. This is where I do 80% of the code. Since most of the work is building the HTML. This works great for most cases.</p>
<p>In the case of the Covid-19 tracker, there is client-side code I wanted to write. In that case, I initialized NPM and brought in a few packages that I'd need (mostly <strong>chartjs</strong>). To avoid having to copy the entire node_modules folder, I opted into using <strong>webpack</strong> to just build the code I needed. This included the libraries I used for the site design(e.g. Bootstrap and jQuery).  Finally I added babel to compile the code in the site. My webpack file was still pretty simple:</p>
<pre><code class=""lang-none"">module.exports = {
  mode: &quot;development&quot;,
  entry: {
    &quot;main&quot;: &quot;./js&quot;,
    &quot;libs&quot;: &quot;./js/libs&quot;
  },
  devtool: 'inline-source-map',  
  module: {
    rules: [
      {
        test: /\.css$/i,
        use: ['style-loader', 'css-loader'],
      },
      {
        test: /\.m?js$/,
        exclude: /(node_modules|bower_components)/,
        use: {
          loader: 'babel-loader',
          options: {
            presets: ['@babel/preset-env']
          }
        }     
      }
    ],
  },
};
</code></pre>
<p>Then I just created a couple of scripts in my package.json so I could easily run the builds:</p>
<pre><code>  &quot;scripts&quot;: {
    &quot;build&quot;: &quot;webpack --config webpack.prod.js&quot;,
    &quot;dev&quot;: &quot;webpack --watch --config webpack.dev.js&quot;
  },
</code></pre>
<p>Then I just needed two consoles to run the two commands: &lsquo;npm run watch&rsquo; and 'lite-server .'.</p>
<p>Then I could just develop the web site.</p>
<h2 id=""deployment"">Deployment</h2>
<p>The magic for me is that deployment becomes really easy. I could have opted to using GitHub Pages which I really like, but since I've been dropping these in Azure AppServices, I opted to just create a super simple container.</p>
<p>A while back my eyes were opened to nginx. This is a simple linux distro that is super small and just serves files. By using it, my dockerfile ends up incredibly simple:</p>
<pre><code>FROM nginx:alpine
COPY ./src/*.html /usr/share/nginx/html
COPY ./src/dist /usr/share/nginx/html/dist
</code></pre>
<p>All I needed in this case was any HTML that I needed (the /usr/share/nginx/html is the directory where your site will be hosted in) as well as the compiled code.</p>
<p>While not exactly elegant, I decided to include all the CSS with webpack too which is any I just need the dist folder in my case.</p>
<p>Then it was as simple as creating a simple command to push the container to a registry (in this case since it's public, I just used docker's registry):</p>
<pre><code>cd ./src
npm run build
cd ..
docker build . -t covidstates:latest
docker tag covidstates:latest shawnwildermuth/covidstates:latest
docker push shawnwildermuth/covidstates:latest
</code></pre>
<p>THis command builds the production code, then builds the docker image. Tags it for docker's registry and pushes it up. With that done, you can just point a new AppServices' instance to this new container. (See my previous article on AppServices and Docker images for how to do that here: <a href=""http://wildermuth.com/2020/02/02/ASP-NET-Core-in-Azure-App-Services-Docker-Images---Part-2"">http://wildermuth.com/2020/02/02/ASP-NET-Core-in-Azure-App-Services-Docker-Images---Part-2</a>).</p>
<p>Whenever I make a change, I just push a new copy and it's live. Useful links:</p>
<blockquote>
<p><a href=""https://www.npmjs.com/package/lite-server"">Lite Server</a></p>
</blockquote>
<blockquote>
<p><a href=""https://www.nginx.com/"">nginx</a></p>
</blockquote>
<blockquote>
<p><a href=""https://webpack.js.org/"">WebPack</a></p>
</blockquote>
<blockquote>
<p><a href=""https://covidstates.azurewebsites.net"">COVID-19 Tracking by State</a></p>
</blockquote>
<blockquote>
<p><a href=""https://github.com/shawnwildermuth/covidstates"">GitHub Repo</a></p>
</blockquote>
<p>Let me know if this was useful!</p>
"
      },
      new BlogStory()
      {
        Id = 2,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/inclusion.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""/img/vue-ad.jpg""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""/img/ps_logo.png"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre><code>c:/>dnx web</code></pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 3,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""/img/vue-ad.jpg"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
       new BlogStory()
      {
        Id = 4,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><img style=""float: right; display: inline"" src=""/img/ps_logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      },
      new BlogStory()
      {
        Id = 5,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://wildermuth.com/images/8931dc63-9e1e-491a-a64a-3a0eb4a67101..png""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""/img/bs-ad.jpg"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre><code>c:/>dnx web</code></pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 6,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""/img/mvp_horizontal_blueonly.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
       new BlogStory()
      {
        Id = 7,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><img style=""float: right; display: inline"" src=""/img/ps_logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      },
      new BlogStory()
      {
        Id = 8,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""/img/ps_logo.png""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""/img/ps_logo.png"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre><code>c:/>dnx web</code></pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 9,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""/img/ps_logo.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
       new BlogStory()
      {
        Id = 10,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><img style=""float: right; display: inline"" src=""/img/ps_logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      },
      new BlogStory()
      {
        Id = 11,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        DatePublished = DateTime.UtcNow,
        Body = @"<p><a href=""/img/ps_logo.png""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""/img/ps_logo.png"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre><code>c:/>dnx web</code></pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 12,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""http://wildermuth.com/images/DevIntersection_3.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
       new BlogStory()
      {
        Id = 13,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><img style=""float: right; display: inline"" src=""/img/ps_logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      },
      new BlogStory()
      {
        Id = 14,
        IsPublished = true,
        Title = "Angular 2 and ASP.NET Core - A Webcast",
        Slug = "2016/2/1/Angular_2_and_ASP_NET_Core_-_A_Webcast",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><a href=""http://wildermuth.com/images/8931dc63-9e1e-491a-a64a-3a0eb4a67101..png""><img title=""image"" style=""float: right; display: inline"" alt=""image"" src=""/img/ps_logo.png"" width=""234"" align=""right"" height=""161""></a>I’ve been toying around with getting Angular 2 working in a simple ASP.NET Core app. There are some specific caveats with getting it to work in Microsoft’s new framework. Let me show you how.</p> <p>Now Angular 2 is in early beta and ASP.NET Core is in RC1 so I am taking a risk. I’m going to have a live webcast and I’ll build an Angular 2 app in an ASP.NET Core application. Come watch me walk the tightrope. No promises.</p> <p>UPDATE: The webcast went great and you can now view all hour and twenty minutes of it on YouTube. Wasn’t perfect, but I hope you can learn a bit from it. The source I used in the webcast was from my re-write of my blog in ASP.NET Core. You can find that here on GitHub:</p> <blockquote> <p><a href=""http://github.com/shawnwildermuth/wilderblog"">http://github.com/shawnwildermuth/wilderblog</a> </p></blockquote> <p>The webcast will be on Google Hangouts On Air at 2pm ET on February 4th. No signup necessary!</p> <blockquote> <p><a title=""https://www.youtube.com/watch?v=ufBbGMLgSj0"" href=""https://www.youtube.com/watch?v=ufBbGMLgSj0"">https://www.youtube.com/watch?v=ufBbGMLgSj0</a></p></blockquote> <p>Or you can watch it here directly:</p> <p><iframe height=""315"" src=""https://www.youtube.com/embed/ufBbGMLgSj0?rel=0"" frameborder=""0"" width=""560"" allowfullscreen></iframe></p> <p>Hope you enjoy it!</p><p><pre><code>c:/>dnx web</code></pre></p><p></p>"
      },
      new BlogStory()
      {
        Id = 15,
        IsPublished = true,
        Title = "The Week at DEVIntersection",
        Slug = "2015/10/29/The_Week_at_DEVIntersection",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><a href=""http://devintersection.com""><img title=""Print"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""Print"" src=""http://wildermuth.com/images/DevIntersection_3.png"" width=""240"" align=""right"" height=""81""></a>I want to thank all the great attendees I met at this week’s DEVIntersection (Fall 2015) conference in Vegas! Richard Campbell and company put on a great show!</p> <p>I had the opportunity to do three talks and two of them went well (if you were at my Bootstrap talk, you know what I’m talking about). In any case, I wanted to share the slide and code with the attendees so here it is:</p> <h3>API Design</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-APIDesign.pdf"" target=""_blank"">Slides</a></p></blockquote> <h3>Looking Ahead to Bootstrap 4</h3> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-slides.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-BS4-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p> <h3>Entities or&nbsp; View Models in ASP.NET Development</h3></p> <blockquote> <p><a href=""http://wildermuth.com/downloads/devintersection-fall2015-ViewModels.pdf"" target=""_blank"">Slides</a></p> <p><a href=""http://Wildermuth.com/downloads/devintersection-fall2015-ViewModels-demo.zip"" target=""_blank"">Demos</a></p></blockquote> <p>Let me know if you attended the talk and how you liked them!</p>"
      },
       new BlogStory()
      {
        Id = 16,
        IsPublished = true,
        Title = "Hello World Road Trip - So Far",
        Slug = "2016/3/7/Hello_World_Road_Trip_-_So_Far",
        Categories = "ASP.NET, Speaking",
        DatePublished = DateTime.UtcNow,
        FeatureImageUrl = "https://wilderminds.blob.core.windows.net/img/pexels-karolina-grabowska-4498136.jpg",
        Body = @"<p><img style=""float: right; display: inline"" src=""/img/ps_logo.png"" width=""200"" align=""right"" height=""200"">We’re in San Francisco today and I thought it would be a good time to write a quick update to the trip. As some of you know, we’re currently in the middle of a twenty-five city trip and so far so good.</p> <p>Tomorrow night we do the event here in San Francisco (with the amazing Beth Massi as our guest) and I’m excited to do our sixth event. It’s been an amazing couple of weeks and we can’t wait for the rest of the trip to unfold.</p> <p>Me and my wife are travelling to each city to put on the road trip and we’ve done events in Atlanta, Birmingham, Austin, Phoenix, and San Diego. I’ve had the pleasure of interviewing Jim Wooley, Todd Miranda, Rod Paddock, Joe Guadagno, and Tim Huckaby so far. </p> <p>I’m really excited by the support I’ve gotten from all our sponsors (including Pluralsight, Infragistics, DevExpress, Telerik, and GrapeCity). So far we’ve given away over $35,000 in prizes from our sponsors. </p> <p>Here are a few thoughts about every stop:</p> <h3>Atlanta</h3> <p><a href=""http://wildermuth.com/images/accb73e4-212e-487f-b708-439e2242bd52..jpg""><img title=""JimWooley_Atlanta"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""JimWooley_Atlanta"" src=""http://wildermuth.com/images/185794e5-1057-46a8-838f-1085816d611c..jpg"" width=""204"" align=""right"" height=""98""></a>When I started our first event, I told the attendees that they were the beta testers. I didn’t know how true that was. Jim Wooley and I recorded a great talk but little did I know at the time that I forgot to press record when we started the podcast. Lucky for me I was still home and plied him with BBQ to come by the house and re-record the podcast with an audience of two (our wives). </p> <h3>Birmingham</h3> <p><a href=""http://wildermuth.com/images/841dd7ec-16d7-45fa-9290-86520ee6758e..jpg""><img title=""20160218_191145"" style=""border-top: 0px; border-right: 0px; background-image: none; border-bottom: 0px; float: right; padding-top: 0px; padding-left: 0px; border-left: 0px; display: inline; padding-right: 0px"" border=""0"" alt=""20160218_191145"" src=""http://wildermuth.com/images/93037cf2-95de-4bbc-b37a-34c272fe39b5..jpg"" width=""204"" align=""right"" height=""113""></a>Out of Atlanta, we headed for Alabama and the first actual road stop. We had an enthusiastic group and they asked great questions during my ASP.NET Core talk. Todd had a great story (his podcast comes out tomorrow) and loved his opinions about being a manager of developers.</p> <h3>Austin</h3> <p>We were excited about making a stop in Austin to try their legendary BBQ. You might not know this, but the amazing Fox Brothers BBQ in Atlanta in literally out our backyard so we love our BBQ. Austin didn’t disappoint. Our stop in Austin was complete with Rod Paddock’s great interview that covered his love of writing and development and how he’s mixed the two masterfully. </p>   <h3>Phoenix</h3> <p><a href=""http://wildermuth.com/images/4764affc-eb6e-4106-b55e-f526cbc78d4d..jpg""><img title=""P1020352"" style=""float: right; display: inline"" alt=""P1020352"" src=""http://wildermuth.com/images/b21c27f0-a9c0-4465-aee8-46208f1b62f7..jpg"" width=""200"" align=""right"" height=""126""></a>We were really glad to get to Phoenix so we could put our jackets away for a couple of stops. We visited the great Music Instrument Museum and then headed over for our event in Phoenix. This stop was marred by a very late delivery of pizza and a schedule mistake on my part so the audience was antsy for us to start. Joe Guadagno saved the day with his compelling story of how he got started.</p> <h3>San Diego</h3> <p><a href=""http://wildermuth.com/images/56e5f578-9bce-4528-bd11-58cbfaa7dffe..jpg""><img title=""P1020365"" style=""float: right; display: inline"" alt=""P1020365"" src=""http://wildermuth.com/images/dda700ee-39bd-4f13-bcd0-2eb5f8177c7c..jpg"" width=""200"" align=""right"" height=""133""></a>Finally, in San Diego we were lucky to find a twelve hour window when Tim Huckaby was home and got his story of how he got started. He really compelled me to start looking at the Hololens as the real deal. If only someone could give me the 3K to get the developer edition.</p> <p>So that’s the story so far. If you want to see what cities we’re headed to, go visit the road trip site here:</p> <blockquote> <p><a href=""http://hwroadtrip.com"">http://hwroadtrip.com</a></p></blockquote> <p>Don’t forget, you can see the code from the demos of all the stops of the road trip here:</p> <blockquote> <p><a title=""https://github.com/shawnwildermuth/HWRoadTripDemos"" href=""https://github.com/shawnwildermuth/HWRoadTripDemos"">https://github.com/shawnwildermuth/HWRoadTripDemos</a></p></blockquote> <h3></h3> <p>Thanks to all the great guests and attendees for making our road trip a fun success. See you at your city coming soon! </p>"
      }
    };
  }
}
