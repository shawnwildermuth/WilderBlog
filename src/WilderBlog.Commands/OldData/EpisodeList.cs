using System;
using System.Collections.Generic;
using System.Linq;

namespace WilderBlog.OldData
{
  public class EpisodeList : List<Episode>
  {
    public EpisodeList()
    {
      CreateEpisodes();
    }

    void CreateEpisodes()
    {
      this.AddRange(new Episode[] {

        //new Episode()
        //{
        //  EpisodeNumber = 69,
        //  Blurb = new string[]
        //  {
        //    ""
        //  },
        //  PodcastName = "hwpod",
        //  Status = EpisodeStatus.Planned,
        //  GuestName = "Julie Yack",
        //  GuestHeadshot = "http://wildermuth.com/images/hwpod/julie-yack.jpg",
        //  GuestBio = new string[]
        //  {
        //    @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
        //  },
        //  GuestLinks = new EpisodeLink[]
        //  {
        //    new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
        //    new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
        //  },
        //  GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
        //  GuestFirstMachineName = "IBM Card Punch Machine",
        //  GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
        //  AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
        //  YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
        //  Length = new TimeSpan(),
        //  PublishedDate = DateTime.Parse("2016/05/09")
        //},

        new Episode()
        {
          EpisodeNumber = 68,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Planned,
          GuestName = "Merrick Christensen",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Merrick-Christensen.jpg",
          GuestBio = new string[]
          {
            @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
            new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
          },
          GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
          GuestFirstMachineName = "IBM Card Punch Machine",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
          YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/04/25")
        },

        new Episode()
        {
          EpisodeNumber = 67,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Planned,
          GuestName = "Richard Hundhausen",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Richard-Hundhausen.jpg",
          GuestBio = new string[]
          {
            @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
            new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
          },
          GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
          GuestFirstMachineName = "IBM Card Punch Machine",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
          YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/04/18")
        },

        new Episode()
        {
          EpisodeNumber = 63,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Scott Guthrie",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/scott-guthrie.jpg",
          GuestBio = new string[]
          {
            @"As executive vice president of the Microsoft Cloud and Enterprise group, Scott Guthrie is responsible for the company’s cloud infrastructure, server, database, management and development tools businesses. His engineering team builds Microsoft Azure, Windows Server, SQL Server, Active Directory, System Center, Visual Studio and .NET.",
            @"Prior to leading the Cloud and Enterprise group, Guthrie helped lead Microsoft Azure, Microsoft’s public cloud platform. Since joining the company in 1997, he has made critical contributions to many of Microsoft’s key cloud, server and development technologies and was one of the original founders of the .NET project. Guthrie graduated with a bachelor’s degree in computer science from Duke University. He lives in Seattle with his wife and two children.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/scottgu" },
            new EpisodeLink() { Name = "Blog", Link = "https://weblogs.asp.net/scottgu" },
            new EpisodeLink() { Name = "Microsoft Azure", Link = "http://azure.microsoft.com" },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/IBM_Personal_Computer",
          GuestFirstMachineName = "IBM PC",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-pc.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode63.mp3",
          YouTubeLink = "https://youtu.be/nVE7yp_yeBU",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/04/11")
        },

        //new Episode()
        //{
        //  EpisodeNumber = 64,
        //  Blurb = new string[]
        //  {
        //    ""
        //  },
        //  PodcastName = "hwpod",
        //  Status = EpisodeStatus.Planned,
        //  GuestName = "Erik Mork",
        //  GuestHeadshot = "http://wildermuth.com/images/hwpod/erik-mork.jpg",
        //  GuestBio = new string[]
        //  {
        //    @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
        //  },
        //  GuestLinks = new EpisodeLink[]
        //  {
        //    new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
        //    new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
        //  },
        //  GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
        //  GuestFirstMachineName = "IBM Card Punch Machine",
        //  GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
        //  AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
        //  YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
        //  Length = new TimeSpan(),
        //  PublishedDate = DateTime.Parse("2016/04/04")
        //},

        new Episode()
        {
          EpisodeNumber = 62,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Beth Massi",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/beth-massi.jpg",
          GuestBio = new string[]
          {
            @"Beth is a Senior Product Manager for .NET at Microsoft and a long-time community champion for .NET developers. She helps developers build amazing things. Before Microsoft, she spent many years building business apps for small businesses as well as large enterprises, primarily on the .NET stack, and was a Microsoft MVP. She is a speaker at various software development events and you can find her on a variety of developer sites. Follow her on twitter and GitHub: @BethMassi",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/bethmassi" },
            new EpisodeLink() { Name = "GitHub", Link = "http://github.com/bethmassi" },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/Atari_8-bit_family#The_early_machines:_400_and_800",
          GuestFirstMachineName = "Atari 400",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/atari400.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode62.mp3",
          YouTubeLink = "https://youtu.be/Rn40N7q-6AI",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/04/04")
        },

        new Episode()
        {
          EpisodeNumber = 61,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Tim Huckaby",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/tim-huckaby.jpg",
          GuestBio = new string[]
          {
            @"Tim Huckaby is an industry luminary focused on Emerging User Experiences, User Interaction Design and the Natural User Interface (NUI). Mr. Huckaby has been awarded many times for the highest rated keynotes & presentations for Microsoft and many other industry & technology conferences like CES and events world-wide. Mr. Huckaby is consistently rated in the top 10% of all speakers at these events. Having worked for or with Microsoft for over 25 years, Mr. Huckaby has been on stage with, and done numerous keynote demos for many Microsoft executives including Bill Gates and Steve Ballmer.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/timhuckaby" },
            new EpisodeLink() { Name = "Blog", Link = "http://blogs.interknowlogy.com/author/timhuckaby/" },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/Mainframe_computer",
          GuestFirstMachineName = "Mainframe Computers",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/mainframe.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode61.mp3",
          YouTubeLink = "https://youtu.be/ynLSt78h2is",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/03/21")
        },

        //new Episode()
        //{
        //  EpisodeNumber = 61,
        //  Blurb = new string[]
        //  {
        //    ""
        //  },
        //  PodcastName = "hwpod",
        //  Status = EpisodeStatus.Planned,
        //  GuestName = "Joseph Guadagno",
        //  GuestHeadshot = "http://wildermuth.com/images/hwpod/Joseph-Guadagno.jpg",
        //  GuestBio = new string[]
        //  {
        //    @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
        //  },
        //  GuestLinks = new EpisodeLink[]
        //  {
        //    new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
        //    new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
        //  },
        //  GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
        //  GuestFirstMachineName = "IBM Card Punch Machine",
        //  GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
        //  AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
        //  YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
        //  Length = new TimeSpan(),
        //  PublishedDate = DateTime.Parse("2016/03/21")
        //},

        new Episode()
        {
          EpisodeNumber = 60,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Rod Paddock",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/rod-paddock.jpg",
          GuestBio = new string[]
          {
            @"Rod Paddock is the editor of CODE Magazine. Rod has been a software developer for more than 10 years and has worked with tools like Visual Studio .NET SQL Server, Visual Basic, Visual FoxPro, Delphi and numerous others. Rod is president of Dash Point Software, Inc. Dash Point is an award winning software development firm that specializes in developing applications for small to large businesses. Dash Point has delivered applications for numerous corporations like: Six Flags, First Premier Bank, Intel, Microsoft and the US Coast Guard. Rod is also VP of Development for SQL Server tools maker, Red Matrix Technologies. (www.redmatrix.com).",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/rodpaddock" },
            new EpisodeLink() { Name = "Editor for CODE Magazine", Link = "http://www.codemag.com/People/Bio/Rod.Paddock" },
            new EpisodeLink() { Name = "Blog", Link = "https://lostechies.com/rodpaddock/" }
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_IIe",
          GuestFirstMachineName = "Apple ][e",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2e.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode60.mp3",
          YouTubeLink = "https://youtu.be/HmFwtMyTrpU",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/03/14")
        },

        new Episode()
        {
          EpisodeNumber = 59,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Todd Miranda",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/todd-miranda.jpg",
          GuestBio = new string[]
          {
            @"Todd Miranda is a consultant, trainer, and author. He has been developing on various platforms for over 20 years and has been involved with .NET since it was first released in 2000. He has worked with many of the .NET platforms but focuses primarily on ASP.NET. He is the owner of NxtDimension Solutions and provides consulting and training on the Microsoft stack. Todd has been awarded a Microsoft MVP for the last 7 years. He is the co-founder of the Birmingham .NET User Group and remains active in the development community. He has recorded hundreds of online training videos on Microsoft development topics including security, JavaScript, Silverlight, WPF, Expression and ASP.NET. He is an INETA speaker and regularly presents at user groups, community events, and technical conferences.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/toddmiranda" },
            new EpisodeLink() { Name = "Nxt Dimension Solutions", Link = "http://www.nxtdimension.com/" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/commodore_64",
          GuestFirstMachineName = "Commodore 64",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/c64.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode59.mp3",
          YouTubeLink = "https://youtu.be/AePsZF9AAFk",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/03/07")
        },

        new Episode()
        {
          EpisodeNumber = 58,
          Blurb = new string[]
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jim Wooley",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jim-wooley.jpg",
          GuestBio = new string[]
          {
            @"By day, Jim Wooley is a consultant for Slalom Consulting, In his free time, Jim is a frequent speaker, INETA Regional Speaker, MVP, and author of ""LINQ in Action"". He is always striving to stay at the forefront of technology and enjoys the thrill of a new challenge. He has been active evangelizing LINQ since it's announcement in 2005. In addition, he attempts to pass on the insights he has gained by being active in the community, including organizing and speaking at code camps and regional events, including DevLink, DevWeek, CodeMash, CodeStock, VS Live, and MIX.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/jimwooley" },
            new EpisodeLink() { Name = "Blog", Link = "http://www.thinqlinq.com/" },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/Mainframe_computer",
          GuestFirstMachineName = "Mainframe Computers",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/mainframe.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode58.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=6Ug42XGdAiE",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/02/29")
        },

        new Episode()
        {
          EpisodeNumber = 57,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Billy Hollis",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/billy-hollis.jpg",
          GuestBio = new string[] 
          {
            @"Billy is internationally known for his work on user experience design and native software development. His team, based in Nashville, Tennessee, has created modern apps hailed around the world for innovation and effective use of advanced user interface technologies. Billy offers training on user experience design for any platform, and technical classes on XAML technologies, including the Universal Windows Platform. You can see Billy at major conferences all over the world, usually doing sessions to help developers to become more focused on designing and developing software that users love.",
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/billyhollis" },
            new EpisodeLink() { Name = "Blog", Link = "http://nextver.com/site/blog/" },
          },
          GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
          GuestFirstMachineName = "IBM Card Punch Machine",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode57.mp3",
          YouTubeLink = "https://youtu.be/U8ExXjrkgS0",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2016/01/11")
        },

        new Episode()
        {
          EpisodeNumber = 56,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Peter Ritchie",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/peter-ritchie.jpg",
          GuestBio = new string[] 
          {
            @"Currently Software Architect at Quicken Loans, Peter has over 12 years' experience working with .NET applications in C#. Prior to focusing on C#, Peter worked primarily in C/C++, which accounts for the majority of his 26 years of programming and design experience. Peter works with a variety of applications and systems including WinForms/WPF applications, client server applications, distributed applications, and web applications. Components include Windows services, TCP servers, TCP clients, HTTP server, and HTTP clients. Peter has also worked with a variety of middleware products including RabbitMQ and MSMQ.",
            @"Peter has spoken internationally on a variety of topics including unit test design and management, asynchronous programming, advanced .NET language features and syntax, concurrent and parallel programming and distributed programming.  Peter is the author of Refactoring with Visual Studio 2010 and Visual Studio 2010 Best Practices."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/peterritchie" },
            new EpisodeLink() { Name = "Blog", Link = "http://blog.peterritchie.com/" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_II",
          GuestFirstMachineName = "Apple ][",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode56.mp3",
          YouTubeLink = "https://youtu.be/LzXKuIVpVPs",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/11/30")
        },

        new Episode()
        {
          EpisodeNumber = 55,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Rick Strahl",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/rick-strahl.jpg",
          GuestBio = new string[] 
          {
            @"Rick Strahl is the Big Kahuna and janitor at West Wind Technologies located on the beautiful island of Maui, Hawaii. Between windsurf sessions and spikey haired adventures, Rick has been a software developer for over 25 years, developing business and Web applications since the very early days of the Web when you needed a hand crank (or a pair of wire splicers) to get online. Today Rick builds client centric Web applications and services for customers with HTML5, JavaScript and mobile Web technologies, using AngularJS on the front end, and  the ASP.NET stack on the back end. Rick’s company West Wind Technologies also produces a number of developer related tools including West Wind WebSurge, West Wind Web Monitor and Html Help Builder.  He also maintains a host of open source libraries at  http://github.com/RickStrahl and you can find Rick’s blog at weblog.west-wind.com or contact him directly at rstrahl@west-wind.com."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/rickstrahl" },
            new EpisodeLink() { Name = "His Band", Link = "https://en.wikipedia.org/wiki/Attitude_Adjustment" },
            new EpisodeLink() { Name = "Rick with Long Hair", Link = "http://americanparanoia.com/" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_IIe",
          GuestFirstMachineName = "Apple ][e",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2e.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode55.mp3",
          YouTubeLink = "http://youtu.be/2lhlcY5VK_4",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/08/31")
        },

        new Episode()
        {
          EpisodeNumber = 54,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jeff Handley",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jeff-handley.jpg",
          GuestBio = new string[] 
          {
            @"Jeff Handley works at Concur and is focusing on the UI for web applications. He previously worked at Microsoft as the Development Lead for NuGet and WCF RIA Services. Jeff has been building and maturing software projects for 20 years. His largest projects have covered education, healthcare waste management, fantasy football, credit/mortgage, and point of sale. Throughout his career, he keeps getting drawn back to web application development."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/jeffhandley" },
            new EpisodeLink() { Name = "Blog", Link = "http://jeffhandley.com/" },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/IBM_Personal_System/2",
          GuestFirstMachineName = "IBM PS/2",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-ps2.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode54.mp3",
          YouTubeLink = "http://youtu.be/D3U7lxMfqg8",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/08/17")
        },


        new Episode()
        {
          EpisodeNumber = 53,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Barry Dorrans",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/barry-dorrans.jpg",
          GuestBio = new string[] 
          {
            @"Barry is the security czar for ASP.NET which means he gets to look at the framework, tools and template code, searching for potential insecurities and sometimes even fixing them. He also triages publically and privately reported vulnerabilities before getting someone else to fix them which means he gets all of the fun and none of the responsibility. He is rude and objectionable on twitter as @blowdart."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/blowdart" },
            new EpisodeLink() { Name = "BBC Microbit Device", Link = "https://news.microsoft.com/en-gb/2015/07/07/microsoft-and-the-bbc-microbit-a-million-ways-to-inspire-a-generation/" },
            new EpisodeLink() { Name = "Microsoft Research BBC Microbit Device Page", Link = "http://research.microsoft.com/microbit/" },

          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/ZX_Spectrum",
          GuestFirstMachineName = "Sinclair ZX Spectrum",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/zx-spectrum.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode53.mp3",
          YouTubeLink = "http://youtu.be/ycl1Y3d-MW4",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/07/27")
        },

        new Episode()
        {
          EpisodeNumber = 52,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Matt Pietrek",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/matt-pietrek.jpg",
          GuestBio = new string[] 
          {
            @"With over 25 years in the software industry, Matt Pietrek has had quite the interesting ride. Starting at Borland in the late 1980s during the heady days of the Microsoft/Borland “compilers wars”, he got his first, intoxicating taste of OS internals, debuggers and tools. From there he spent a decade at NuMega Technologies, working on seminal, award-winning products like BoundsChecker and SoftIce. Next was a seven year stint at Microsoft where he worked on the Visual Studio debugger & profiler teams, Red Dog (now known as Azure), and Hyper-V. He currently works at Skytap, a cloud computing company. Along the way, he wrote several books on Windows internals, as well as numerous articles and columns for magazines just as MSJ/MSDN, PC Magazine, and Byte. When not slinging Python code or groveling through logs, Matt indulges his passion for distilled spirits and cocktails. He’s got a serious, ever growing collection of rums, and writes the CocktailWonk blog about his spirited adventures: http://cocktailwonk.com"
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.wheaty.net/" },
            new EpisodeLink() { Name = "Cocktail Wonk", Link = "http://cocktailwonk.com"}
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Ti-99",
          GuestFirstMachineName = "TI-99",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ti99.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode52.mp3",
          YouTubeLink = "http://youtu.be/NbzlDsG13Ts",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/04/02")
        },



        new Episode()
        {
          EpisodeNumber = 51,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Frans Bouma",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/frans-bouma.jpg",
          GuestBio = new string[] 
          {
            @"Frans Bouma is the creator and lead developer of LLBLGen Pro, a leading ORM and Entity Modeling solution for .NET. Programming professionally since '94, after he (finally) got his B.sc in Computer Science. Frans wrote his first code back in '86 on a Toshiba HX-10 MSX computer and has been fascinated about telling computer hardware to do what you want by writing software ever since. In his spare time he spent more than a decade in the underground scene called 'Demoscene', first on Commodore Amiga 500 and later on PC, writing graphical demos and computer music. "
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "LLBLGen Pro", Link = "http://www.llblgen.com" },
            new EpisodeLink() { Name = "Blog", Link = "http://weblogs.asp.net/fbouma" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/FransBouma" },
          },
          GuestFirstMachineLink = "http://www.msx.org/wiki/Toshiba_HX-10",
          GuestFirstMachineName = "Toshiba HX-10 MSX",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/toshiba-msx-hx10.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode51.mp3",
          YouTubeLink = "http://youtu.be/Hf0yvzeKDNY",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/02/24")
        },

       
        new Episode()
        {
          EpisodeNumber = 50,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Keith Elder",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/keith-elder.jpg",
          GuestBio = new string[] 
          {
            @"Keith Elder is the co-host of the popular online technology podcast Deep Fried Bytes. He is also a Director of Software Engineering at Quicken Loans, the nation’s largest online mortgage lender based in Detroit, MI. Keith is an experienced technologist, systems administrator, software engineer, speaker, trainer and all around geek. He speaks throughout the United States at major technical conferences, Code Camps, and .Net User Groups. Keith’s ability to explain complex topics with a friendly common sense southern attitude make him a highly regarded speaker at technical conferences. You can read more about Keith’s interests, hobbies, rants and raves on his blog at http://keithelder.net/ and follow him on twitter at http://twitter.com/keithelder."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://keithelder.net/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/keithelder" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Timex_Sinclair_1000",
          GuestFirstMachineName = "Timex Sinclair 1000",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/timexsinclair1000.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode050.mp3",
          YouTubeLink = "http://youtu.be/l7_TGkB4MBk",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/02/01")
        },

        new Episode()
        {
          EpisodeNumber = 49,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Scott Stanfield",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/scott-stanfield.jpg",
          GuestBio = new string[] 
          {
            @"Scott Stanfield is the founder and CEO of Vertigo Software, Inc., a digital design and development shop for the media & entertainment business. He is a frequent public speaker, presenting on software technology and design for the past 20 years. Vertigo is making TV Everywhere happen for the major US broadcasters on mobile, desktop and consoles.",
            @"Before starting Vertigo in 1997, Scott worked at Pixar in Point Richmond, California, which happens to be the current home of Vertigo. Scott holds a BS in Computer Science for Cal Poly, San Luis Obispo. Follow Scott on Twitter at @seesharp or email to scott@vertigo.com."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Vertigo", Link = "http://vertigo.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/seesharp" },
            new EpisodeLink() { Name = "Typography for Lawyers", Link = "http://typographyforlawyers.com/"}
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Atari_8-bit_family",
          GuestFirstMachineName = "Atari 800",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/atari800.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode049.mp3",
          YouTubeLink = "http://youtu.be/F4iN55bPYh8",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/01/15")
        },


        new Episode()
        {
          EpisodeNumber = 48,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Dave Ward",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Dave-Ward.jpg",
          GuestBio = new string[] 
          {
            @"Dave Ward is an independent consultant and author, specializing in projects ranging from ASP.NET, to Node.js, to JavaScript single page applications, to hybrid mobile apps. With twenty years of experience developing for the web, he has been recognized as a Microsoft Regional Director, ASP.NET MVP, and member of the ASPInsiders. To learn more or to get in touch with Dave, you can visit his blog at http://Encosia.com or find him on Twitter as @Encosia."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://encosia.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/encosia" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80_Color_Computer",
          GuestFirstMachineName = "TRS-80 Color Computer",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80coco.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode48.mp3",
          YouTubeLink = "http://youtu.be/jRqUlThXQDU",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2015/01/01")
        },

        new Episode()
        {
          EpisodeNumber = 47,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Steve Smith",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/steve-smith.jpg",
          GuestBio = new string[] 
          {
            @"Steve is an entrepreneur and software developer with a passion for building quality software as effectively as possible. He is currently the Chief Technology Officer of Falafel Software. Steve has published several courses on Pluralsight, covering DDD, SOLID, design patterns, and software architecture. He's a Microsoft Regional Director and MVP, a frequent speaker at developer conferences, an author, and a trainer. Along with his wife and business partner, Michelle Smith, Steve was also the founder of Lake Quincy Media (acquired by The Code Project) and NimblePros (acquired by Telerik). Steve's an ex-Army Engineer officer and Iraq veteran who enjoys playing games and spending time outdoors."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://ardalis.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/ardalis" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://pluralsight.com/training/Authors/Details/steve-smith" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_II_Plus",
          GuestFirstMachineName = "Apple II+",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2plus.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode47.mp3",
          YouTubeLink = "http://youtu.be/urca02GlFes",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/12/15")
        },

        new Episode()
        {
          EpisodeNumber = 46,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Rockford Lhotka",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/rocky-lhotka.jpg",
          GuestBio = new string[] 
          {
            @"Rockford Lhotka is the CTO of Magenic, and is the creator of the widely used CSLA .NET development framework. He is the author of numerous books, and regularly speaks at major conferences around the world. Rockford is a Microsoft Regional Director and MVP. Magenic (www.magenic.com) is a company that specializes in planning, designing, building and maintaining your enterprise’s most mission critical systems. For more information go to www.lhotka.net."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Rocky's Website", Link = "http://www.lhotka.net" },
            new EpisodeLink() { Name = "Blog", Link = "http://www.lhotka.net/weblog" },
            new EpisodeLink() { Name = "CLSA.NET", Link = "http://www.cslanet.com" },
            new EpisodeLink() { Name = "Magenic", Link = "http://www.magenic.com" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/CDC_Cyber",
          GuestFirstMachineName = "Cyber Mainframe",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/cyber-mainframe.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode46.mp3",
          YouTubeLink = "http://youtu.be/t7Y8llomViA",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/11/01")
        },

        new Episode()
        {
          EpisodeNumber = 45,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Deborah Kurata",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/deborah-kurata.jpg",
          GuestBio = new string[] 
          {
            @"Deborah Kurata is an independent software consultant/developer specializing in Web and .NET development using AngularJS, VB.NET, and C#. She is also a Pluralsight author with seven courses to her name.",
            @"Deborah has authored several programming books including the popular ""Doing Objects"" series and is a speaker at conferences such as VSLive! and TechEd. She is also the co-chair of the EastBay.NET user group in the San Francisco Bay/Silicon Valley area."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.bit.ly/DeborahKsBlog" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://pluralsight.com/training/Authors/Details/deborah-kurata" },
            new EpisodeLink() { Name = "'AngularJS Line of Business Applications' Course", Link = "http://www.pluralsight.com/courses/angularjs-line-of-business-applications" },
            new EpisodeLink() { Name = "'Object-Oriented Programming Fundamentals in C#' Course", Link = "http://www.pluralsight.com/courses/object-oriented-programming-fundamentals-csharp" },
            new EpisodeLink() { Name = "'Defensive Coding in C#' Course", Link = "http://www.pluralsight.com/courses/defensive-coding-csharp" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Macintosh_128K",
          GuestFirstMachineName = "Macintosh 128K",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/mac-128k.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode45.mp3",
          YouTubeLink = "http://youtu.be/4RNJfw1M5WA",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/10/20")
        },

        new Episode()
        {
          EpisodeNumber = 44,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Steve Evans",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Steve-Evans.jpg",
          GuestBio = new string[] 
          {
            @"Steve Evans has been doing DevOps since before the term DevOps was invented. He is a Pluralsight Author, five time Microsoft Most Valuable Professional (MVP), and technical Speaker at various industry events. In his spare time he manages a DevOps team at a Silicon Valley Biotech focused on improving the lives of cancer patients. For over 15 years Steve has focused on making technology better for businesses by bridging the gap between IT and Development teams.",  
            @"You can follow his technical blog at http://www.LoudSteve.com or find him on twitter at@TheLoudSteve."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.LoudSteve.com" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/TheLoudSteve" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://www.pluralsight.com/training/Authors/Details?handle=steve-evans" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Kaypro",
          GuestFirstMachineName = "Kaypro",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/kaypro.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode44.mp3",
          YouTubeLink = "http://youtu.be/5XH3yNrNaNM",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/10/13")
        },

        new Episode()
        {
          EpisodeNumber = 43,
          Blurb = new string[] 
          {
            "From professional musician to software developer, that's Walt Ritscher's story. In this episode, Walt and I discuss the migration from keyboards and sequencers to DirectX pixel shaders. It's a bumpy ride that has resulted in Walt's reknown knowledge of UI development."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Walt Ritscher",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/walt-ritscher.jpg",
          GuestBio = new string[] 
          {
            @"Walt's enthusiasm for crafting software interfaces blossomed early.  Just a few days after discovering how to make pixels move around the screen of a borrowed computer he was devouring books on the topic of computer graphics and UI design.  Now he travels the world speaking at software conferences and teaching a diverse portfolio of programming topics for corporate clients. On the consulting side he continues to work with customers like Microsoft, HP, Intel, and Intuit and enjoys being part of the Wintellect consultant group. He has over fifty hours of video training courses available in the WintellectNow, Lynda and Udemy catalogs. He writes for several publications including Code Magazine and has a new ""HLSL and Pixel Shaders for XAML Developer"" book available from O'Reilly Media. His current UI obsession revolves around the Windows 8 Metro, Mobile, ASP.NET MVC and WPF APIs.  This year he is learning as much as he can about Xamarin. You can find his blog at xamlwonderland.com. Walt is also a Microsoft MVP and author of the free Shazzam Shader Editor (shazzam-tool.com).",
            @"He is also deeply involved in the local developer community — founding the .NET Developers Association in Redmond, WA and continues to help organize the Seattle Code Camp, developer hackathons and other local events."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://xamlwonderland.com" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/waltritscher" },
            new EpisodeLink() { Name = "LinkedIn", Link = "http://www.linkedin.com/in/waltritscher" },
            new EpisodeLink() { Name = "Lynda Courses", Link = "http://Lynda.com/waltritscher" },
            new EpisodeLink() { Name = "Wintellect Now Courses", Link = "https://www.wintellectnow.com/Instructor/Bio/WaltRitscher" },
            new EpisodeLink() { Name = "Shazzam Tool", Link = "http://shazzam-tool.com" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_II_series#Apple_IIGS",
          GuestFirstMachineName = "Apple IIGS",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2gs.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode43.mp3",
          YouTubeLink = "http://youtu.be/-UQ48W0dk78",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/10/06")
        },  new Episode()
        {
          EpisodeNumber = 42,
          Blurb = new string[] 
          {
            ""
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Kate Gregory",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/kate-gregory.jpg",
          GuestBio = new string[] 
          {
            @"Kate Gregory has been using C++ since before Microsoft had a C++ compiler, and has been paid to program since 1979. She loves C++ and believes that software should make our lives easier. That includes making the lives of developers easier! She'll stay up late arguing about deterministic destruction or how C++ 11 is not the C++ you remember.",
            @"Kate runs a small consulting firm in rural Ontario and provides mentoring and management consultant services, as well as writing code every week. She has spoken all over the world, written over a dozen books, and helped thousands of developers to be better at what they do. Kate is a Microsoft Regional Director, and a Visual C++ MVP, an Imagine Cup judge and mentor, and an active contributor to StackOverflow and other StackExchange sites. She develops courses for Pluralsight, primarily on C++ and Visual Studio. In 2014 she was Open Content Chair for CppCon, the largest C++ conference ever held, where she also delivered sessions."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.gregcons.com/kateblog/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/gregcons" },
            new EpisodeLink() { Name = "Gregory Consulting Limited", Link = "http://www.gregcons.com/" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://www.pluralsight.com/training/Authors/Details?handle=kate-gregory" },
            new EpisodeLink() { Name = "WATFIV Language", Link = "http://en.wikipedia.org/wiki/WATFIV" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/IBM_3270",
          GuestFirstMachineName = "IBM 3277 Terminal (connected to IBM 370)",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-3227.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode42.mp3",
          YouTubeLink = "http://youtu.be/iusUaucXwB8",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/09/29")
        },

        new Episode()
        {
          EpisodeNumber = 41,
          Blurb = new string[] 
          {
            "This episode is a bit different than my ordinary episode. Carl Franklin and I both have a passion for music and development and that is what this episode is all about.",
            "Carl and I love to play music together at conferences, though he's clearly more polished than I am with those awesome guitar licks. If you are a musician or are just interested in how Carl got started, this is the episode for you!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Carl Franklin",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Carl-Franklin.jpg",
          GuestBio = new string[] 
          {
            @"Carl Franklin is Executive Vice President of App vNext, a software development firm helping to bring about the Internet of Things revolution. Carl is a 20+ year veteran of the software industry, co-host and founder of .NET Rocks!, the first and most widely listened to podcast for .NET developers, a Microsoft MVP for Kinect for Windows, a Microsoft Regional Director, and Senior Executive of Pwop Studios, a full-service audio and video production/post production studio located in Southeastern Connecticut. Carl has been a leader in the .NET community since 2002, and in the Visual Basic (VB) community before that. In the very early days he wrote for Visual Basic Programmer’s Journal, authoring the Q&A column of that magazine as well as many feature articles for VBPJ and other magazines. He has authored two books for John Wiley & Sons on sockets programming in VB, and in 1994 he helped create the very first web site for VB developers, Carl & Gary's VB Home Page."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://carlfranklin.net/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/carlfranklin" },
            new EpisodeLink() { Name = ".NET Rocks Podcast", Link = "http://www.linkedin.com/in/woodring" },
            new EpisodeLink() { Name = "App vNext", Link = "http://www.appvnext.com/" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80",
          GuestFirstMachineName = "TRS-80",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode41.mp3",
          YouTubeLink = "http://youtu.be/VNCYNfPCAZc",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/09/22")
        },

        new Episode()
        {
          EpisodeNumber = 40,
          Blurb = new string[] 
          {
            "I begged Kathleen to do the show and it took forty episodes to get her to agree. Her story starts with an old NASA computer and continues through the leading edge of software development. Kathleen and I talk about the nature of mentoring and surviving in the world of software development."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Kathleen Dollard",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/kathleen-dollard.jpg",
          GuestBio = new string[] 
          {
            @"Kathleen Dollard wants to teach you to code better. There’s more to learn about the tools you use every day and the tools you aren’t yet using.  Coding is our passion and debugging is our challenge - you’ll be happier if you do both better. Kathleen’s written dozens of articles, spoken at conferences and user groups around the world, and pushes Microsoft to respond to your real world needs as a long time MVP. Her Open Source project RoslynDom offers alterative access to information in the .NET Compiler Platform, Roslyn with a load/interrogate/mutate/build SyntaxTree model. She has courses in the Pluralsight library and a series of C# 6 webcasts now available for free on WintellectNOW."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://blogs.msmvps.com/Kathleen/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/KathleenDollard" },
            new EpisodeLink() { Name = "Microsoft MVP", Link = "http://mvp.microsoft.com/en-us/MVP/Kathleen%20Dollard-6550" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://www.pluralsight.com/training/Authors/Details/kathleen-dollard" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/HP_2100",
          GuestFirstMachineName = "HP-2116",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/hp-2100.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode40.mp3",
          YouTubeLink = "http://youtu.be/voa7pWl-smY",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/09/15")
        },
        new Episode()
        {
          EpisodeNumber = 39,
          Blurb = new string[] 
          {
            "If you've been following Silverlight from my old days, I am sure you know the name of Tim Heuer. "
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Tim Heuer",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/tim-heuer.jpg",
          GuestBio = new string[] 
          {
            @"Tim Heuer is a program manager for Microsoft working on the client UI developer platforms working on XAML in Windows and previously Silverlight. Before joining the XAML engineering teams, Tim worked with technical communities across the country helping to foster and build user communities focused on software developer technologies. Tim has worked with Microsoft developer tools and technologies since the early 1990s. Prior to joining Microsoft, he worked as a consultant for 14 years helping to implement technology solutions to enable success in businesses across various industries such as health care, construction, real estate, and electronic commerce to name a few. He's inflicted with the unfortunate disease that his work is also his hobby and he loves technology. You can usually find him behind the keyboard trying to learn something new. You can find him online sharing his thoughts on technology at <a href='http://timheuer.com/blog/'>http://timheuer.com/blog/</a>."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://timheuer.com/blog/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/timheuer" },
            new EpisodeLink() { Name = "Life Balance Blogpost", Link = "http://timheuer.com/blog/archive/2013/05/03/priorities-passion-employment-work-life-balance.aspx " },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Compaq_Portable",
          GuestFirstMachineName = "Compaq Portable",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/compaq-portable.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode39.mp3",
          YouTubeLink = "http://youtu.be/dsxI2HHC-_0",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/09/02")
        },
        new Episode()
        {
          EpisodeNumber = 38,
          Blurb = new string[] 
          {
            "Stephen Forte is bundle of energy and I love talking with him in any situation. If you've loved his Scrum talks and his views on building businesses, you'll love this episode of the Hello World Podcast.",
            "In this episode, Stephen and I sit down and talk all about enterpreneurship and computer science. We talk about the difference betwen a lifestyle business and a business with an exit strategy. If you're thinking of creating your own startup, this is the episode for you!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Stephen Forte",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/stephen-forte.jpg",
          GuestBio = new string[] 
          {
            @"Stephen Forte is the Chief Strategy Officer of the venture backed company, Telerik, a leading vendor of developer and team productivity tools. He is the founder and executive director of Mach5, a Silicon Valley based startup accelerator and co-founder of AcceleratorHK, Hong Kong’s first startup accelerator. Involved in several startups, he was the co-founder of Triton Works, which was acquired by UBM (London: UBM.L) in 2010 and was the Chief Technology Officer and co-founder of Corzen, Inc., which was acquired by Wanted Technologies (TXV: WAN) in 2007. Prior to Corzen, Stephen served as the CTO of Zagat Survey in New York City (acquired by Google in 2011) and also was co-founder of the New York-based software consulting firm The Aurora Development Group. Stephen is also a Certified Scrum Master, Certified Scrum Professional, PMP, and also speaks regularly at industry conferences around the world. He has written several books on application and database development. Stephen has an MBA from the City University of New York. Stephen is also a board member of the Scrum Alliance. An avid mountain climber, Stephen leads a trek in the Mt. Everest region every fall to raise money for charity. After several years as an ex-pat in Hong Kong, Stephen now lives in Silicon Valley with his wife."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.stephenforte.net/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/worksonmypc" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Pc_clone",
          GuestFirstMachineName = "PC Clone",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/pc-clone.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode38.mp3",
          YouTubeLink = "http://youtu.be/A1utQPe5fgY",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/08/25")
        },
        new Episode()
        {
          EpisodeNumber = 37,
          Blurb = new string[] 
          {
            "Clemens Vasters is well known for his contributions as a Software Architect for Microsoft. As many of you, I've always thought of Clemens as a middleware/back-end guy. On this episode, I find out (to my surprise) that he got started in front-end and graphics for TV systems. See how that turned into the Azure Service Bus and other work he does for Microsoft today."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Clemens Vasters",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/Clemens-Vasters.jpg",
          GuestBio = new string[] 
          {
            @"Clemens Vasters is a Software Architect and currently works for Microsoft where he drives the technical strategy for Microsoft Azure Service Bus and other messaging-centric technologies. Before joining Microsoft, Clemens has worked on financial software solutions and in consulting, has spoken at hundreds of events in over 40 countries, and has contributed to a number of open source efforts including starting the dasBlog blog engine. Clemens has a long history educating developers, having taught some of the first available .NET training courses for developers in Europe in early 2002."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://vasters.com/clemensv/" },
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/clemensv" },
            new EpisodeLink() { Name = "Channel 9 Videos", Link = "https://channel9.msdn.com/Events/Speakers/Clemens-Vasters" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://www.pluralsight.com/training/Authors/Details?handle=clemens-vasters" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/ZX81",
          GuestFirstMachineName = "Sinclair ZX-81",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/zx81.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode37.mp3",
          YouTubeLink = "http://youtu.be/GCV523Z2a9w",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/08/18")
        },
        new Episode()
        {
          EpisodeNumber = 36,
          Blurb = new string[] 
          {
            "Troy Hunt is one of those guys that cares about security so I don't have to. In this week show I get to talk to Tony about how he got started both building and breaking software. We talk about the beginnings of his web development career and how that turned into his passion about security.  I hope you enjoy this episode!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Troy Hunt",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/troy-hunt.jpg",
          GuestBio = new string[] 
          {
            @"Troy lives in the two worlds of building software and breaking software, predominantly software running on the web. From the very early days of HTML, Troy has been a web-centric guy all the way through to today’s modern devices either talking over HTTP or pushing angle brackets around. Having drifted towards security, he now focusses on helping developers understand how to break their own apps and build up offensive skills that are complemented by teaching secure coding patterns – if you don’t know how to break it, you don’t know how to protect it! Troy is an Aussie Microsoft MVP for Developer Security living in Sydney and writing at troyhunt.com as well as speaking around the world, training and creating Pluralsight courses.",
            @"When not building or breaking, Troy’s into snowboarding, lots of tennis and fast cars."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.troyhunt.com" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/troyhunt" },
            new EpisodeLink() { Name = "'Have I been Pwnded'", Link = "https://haveibeenpwned.com/" },
            new EpisodeLink() { Name = "Automated Security Analyser for ASP.NET Websites", Link = "https://asafaweb.com/"},
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://pluralsight.com/training/Authors/Details/troy-hunt" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Pc_clone",
          GuestFirstMachineName = "PC Clone",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/pcclone.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode36.mp3",
          YouTubeLink = "http://youtu.be/VsiKwbUIevw",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/08/11")
        },
        new Episode()
        {
          EpisodeNumber = 35,
          Blurb = new string[] 
          {
            "It's funny how intertwined careers can get. I've known of Mike Woodring for years and work with him as a Pluralsight author. Mike has always had a gentle, clear way of fighting through the morass of technical topics.",
            "During this week's podcast, Mike and I got to talk about growing up as the kid who took all his toys apart and how an internship after his freshmen year made him realize that software was what he was really passionate about."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Mike Woodring",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/mike-woodring.jpg",
          GuestBio = new string[] 
          {
            @"Mike is the VP of Developer Content - Enterprise Software at Pluralsight. A former Microsoft C# MVP and multiple U.S. patent holder, Mike has over 20 years of experience developing high performance software systems and training developers around the world. Mike is co-author of Win32 Multithreaded Programming and Debugging Windows Programs: Strategies, Tools, and Techniques for Visual C++ Programmers."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://blog.pluralsight.com/author/mikewoodring" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/mcwoodring" },
            new EpisodeLink() { Name = "LinkedIn", Link = "http://www.linkedin.com/in/woodring" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://www.pluralsight.com/training/Authors/Details?handle=mike-woodring" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Ti-99",
          GuestFirstMachineName = "TI-99",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ti99.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode35.mp3",
          YouTubeLink = "http://youtu.be/5xPCg1FhMH4",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/08/04")
        },
        new Episode()
        {
          EpisodeNumber = 34,
          Blurb = new string[] 
          {
            "You probably know Dan Wahlin from his Pluralsight videos or countless trainings and conferences he has done. I love the way that he simplifies the complex and talks very with clarity no matter the subject.",
            "In this episode, Dan and I talk about how he ended up in web development instead of being a doctor. I think he made the right decision."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Dan Wahlin",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/dan-wahlin.jpg",
          GuestBio = new string[] 
          {
            @"Dan Wahlin founded Wahlin Consulting which provides consulting and training services on Web technologies such as JavaScript, AngularJS, HTML5, Node.js, C#, ASP.NET MVC, Web API, and SharePoint. He’s also a course author on Pluralsight.com and has published several courses covering a range of technologies including the new AngularJS JumpStart course on Udemy.com. Dan speaks at conferences and user groups around the world and has written several books on Web technologies.  Dan blogs at http://weblogs.asp.net/dwahlin, runs the Web Weekly newsletter (a great way to stay up on the latest technologies), and writes columns for various technical magazines. Follow Dan on Twitter @DanWahlin."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://weblogs.asp.net/dwahlin" },
            new EpisodeLink() { Name = "Twitter", Link = "http://pluralsight.com/training/Authors/Details/joe-eames" },
            new EpisodeLink() { Name = "AngularJS Jumpstart Course", Link = "http://tinyurl.com/angularjsjumpstart" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_IIc",
          GuestFirstMachineName = "Apple IIc",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2c.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode34.mp3",
          YouTubeLink = "http://youtu.be/A1QTEb8ENNs",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/07/28")
        },
        new Episode()
        {
          EpisodeNumber = 33,
          Blurb = new string[] 
          {
            "During my recent month in London, I finally got to spend some time chewing the fat with Ian Griffiths. We've been hovering near each other at different companies for sometime. I even helped write an appendix for a book that he co-wrote (with Chris Sells).",
            "So I was delighted to get him on the show and talk about his career path. I won't spoil it, but it does start with a three year-old Ian and punch cards."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Ian Griffiths",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/ian-griffiths.jpg",
          GuestBio = new string[] 
          {
            @"Ian is an independent consultant, developer, speaker, and author. He has written books on Windows Presentation Foundation, Windows Forms, and Visual Studio. He lives in London but can often be found on various developer mailing lists and newsgroups, where a popular sport is to see who can get him to write the longest email in reply to the shortest possible question."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.interact-sw.co.uk/iangblog/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/idg10" },
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://pluralsight.com/training/Authors/Details/ian-griffiths" },
            new EpisodeLink() { Name = "Agenda View Windows Phone App", Link = "http://windows-phone-agenda.com/" },
          },
          GuestFirstMachineLink = "http://www-03.ibm.com/ibm/history/exhibits/vintage/vintage_4506VV4002.html",
          GuestFirstMachineName = "IBM Card Punch Machine",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ibm-cardpunch.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode33.mp3",
          YouTubeLink = "http://youtu.be/W0Ypt97lBgQ",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/07/21")
        },
        new Episode()
        {
          EpisodeNumber = 32,
          Blurb = new string[] 
          {
            "If you've ever had a chance to meet Lino, you know he lights up every room he is in. That's how I've seen him. In this episode, we get to hear from him how he got started and some tips for building a hugely successful consulting company. "
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Lino Tadros",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/lino-tadros.jpg",
          GuestBio = new string[] 
          {
            @"Alain ""Lino"" Tadros is President & CEO of Falafel Software, a Silicon Valley based company, with presence in Colorado,Texas, Michigan, Florida and North Carolina, dedicated to providing world-class consulting, training, and software development for small, medium, and enterprise level businesses. Prior to founding Falafel, Lino was a member of the development team at Borland for Delphi and C++Builder. Lino has been awarded Microsoft MVP status twelve years in a row for his numerous contributions to the C# community and is an expert in .NET, LINQ, ASP.NET, MVC, XAML, Windows Phone and Web Services. Lino is an industry renowned speaker and has given numerous presentations on 5 different continents since 1994. He also currently sits on the Board of Directors of 4 Silicon Valley corporations."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Falafel Software", Link = "http://www.falafel.com" },
            new EpisodeLink() { Name = "Falafel Software Dubai", Link = "http://www.falafelsoft.ae" },
            new EpisodeLink() { Name = "EventBoard Mobile App", Link = "http://www.eventboardmobile.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/linotadros" },
            new EpisodeLink() { Name = "Twitter", Link = "http://blog.falafel.com" }
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/ZX_Spectrum#ZX_Spectrum_128",
          GuestFirstMachineName = "Sinclair ZX Spectrum 128",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/zx-spectrum-128.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode32.mp3",
          YouTubeLink = "http://youtu.be/yGr4zmO9c6Q",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/07/14")
        },
        new Episode()
        {
          EpisodeNumber = 31,
          Blurb = new string[] 
          {
            "I met Joe because of his great work at Pluralsight. We seem to be thinking about the same topics these days. I wanted to hear his story of how he got started. I didn't expect to hear about learning C++ without the benefit of a computer. I think you'll enjoy this one."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Joe Eames",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/joe-eames.jpg",
          GuestBio = new string[] 
          {
            @"Joe is a front end web developer, consultant and freelance author for Pluralsight. Joe has always has worked both full and part time as a technical teacher for over ten years. He is a frequent blogger and speaker, organizer of ng-conf, the AngularJS conference (www.ng-conf.org), and a panelist on the JavaScript Jabber podcast (http://javascriptjabber.com/)"
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Pluralsight Author", Link = "http://pluralsight.com/training/Authors/Details/joe-eames" },
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/josepheames" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_III",
          GuestFirstMachineName = "Apple III",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple3.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode31.mp3",
          YouTubeLink = "http://youtu.be/30ScV3jthu4",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/07/07")
        },

        new Episode()
        {
          EpisodeNumber = 30,
          Blurb = new string[] 
          {
            "While Ted and I were at DevelopMentor at the same time, it wasn't until an MVP summit many years ago that I finally got to hang out with him. I've always loved how he skated the thin line of being in the Java and .NET worlds without seeming to prefer either technology.",
            "We got to talk about not only how he got started but where his love of teaching comes from as well as the different career paths of technical and management. I am really excited about this episode and can barely believe that it's been 30 episodes already!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Ted Neward",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/ted-neward.jpg",
          GuestBio = new string[] 
          {
            "Ted is currently the CTO of iTrellis, a team of experienced technology professionals who promote the Continuous Delivery of high quality new services. He is an authority in Java and .NET technologies, particularly in the areas of Java/.NET integration (both in-process and via integration tools like Web services), back-end enterprise software systems, and virtual machine/execution engine plumbing.",
            "He is the author or co-author of several books, including Professional F# 2.0, Effective Enterprise Java, C# In a Nutshell, SSCLI Essentials, Server-Based Java Programming, and a contributor to several technology journals. Ted is also a Microsoft F# MVP, BEA Technical Director, INETA speaker, former DevelopMentor instructor, frequent worldwide conference speaker, and a member of various Java JSRs. He lives in the Pacific Northwest with his wife, two sons, and eight PCs. "
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://blogs.tedneward.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/tedneward" },
            new EpisodeLink() { Name = "iTrellis", Link = "http://www.itrellis.com/" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_II_Plus",
          GuestFirstMachineName = "Apple II+",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2plus.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode30.mp3",
          YouTubeLink = "http://youtu.be/RzHSaJGO0dg",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/06/23")
        },

        new Episode()
        {
          EpisodeNumber = 29,
          Blurb = new string[] 
          {
            "I met Rob back a bunch of years ago at DevTeach in Vancouver, BC and we were traveling in the same technology circles. Even though Rob insists on loving Visual Basic, I still consider him a friend.",
            "In this episode, I talk with Rob about how important community involvement is to him career and how he encourages the next round of great developers with his community activism."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Rob Windsor",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/rob-windsor.jpg",
          GuestBio = new string[] 
          {
            "Rob Windsor is a Lead SharePoint Consultant with Portal Solutions - a Microsoft Gold Partner based in DC and Boston. He has twenty years experience developing rich-client and web applications with various languages and is currently spending a majority of his time working with SharePoint. Rob is a regular speaker at conferences and community events and he authors content for the Pluralsight On-Demand library. Rob is the founder and past-president of the North Toronto .NET User Group and has been recognized as a Microsoft Most Valuable Professional for his involvement in the developer community."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.msmvps.com/blogs/windsor" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/VAX",
          GuestFirstMachineName = "Digital VAX Machine",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/digital-vax.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode29.mp3",
          YouTubeLink = "http://youtu.be/EMFflRqBXC4",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/06/16")
        },

        new Episode()
        {
          EpisodeNumber = 28,
          Blurb = new string[] 
          {
            "As a veteran of both the world of being an independent software developer and a cog in a machine like Microsoft, Rachel Appel has a great perspective of being a dev in today's world. Rachel and I run into each other at conferences all over the world and I can always count on her for honesty and frankness.",
            "In this episode we talk about how she grew up in a small town and became a software developer. She talks about her shift of focus over the years from developer, consultant and evangelist. Take a listen:"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Rachel Appel",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/rachel-appel.jpg",
          GuestBio = new string[] 
          {
            "Rachel is a 20+ year consultant, author, mentor, and former Microsoft employee in the IT industry who speaks at top industry conferences such as VSLive!, DevConnections, MIX, and more. During her career, Rachel has worked on projects of all sizes from the smallest of apps to the largest enterprise systems at some of the world’s leading companies."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://rachelappel.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/rachelappel" },
            new EpisodeLink() { Name = "MSDN Magazine Column", Link = "http://msdn.microsoft.com/en-us/magazine/ee532098.aspx?sdmr=RachelAppel&sdmi=authors" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_IIe",
          GuestFirstMachineName = "Apple ][e",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2e.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode28.mp3",
          YouTubeLink = "http://youtu.be/_G2Ze73mJf8",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/06/09")
        },

        new Episode()
        {
          EpisodeNumber = 27,
          Blurb = new string[] 
          {
            "Back when I was doing mostly C++, I felt specificly indebted to the great work that John Robbins did both at Numega and his great books on debugging. As .NET became my development world, his insights continued to shape the developer I am today.",
            "In this episode I talk with John about how being a Green Beret informed how he does software development. We also talk about being a twenty-five year old freshman in college and his late start to computing."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "John Robbins",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/john-robbins.jpg",
          GuestBio = new string[] 
          {
            "John is a co-founder of Wintellect (http://www.wintellect) and a course author at WintellectNOW (http://www.wintellectnow.com). In our business it’s good to specialize in something so John specializes in pain: debugging and performance tuning. He’s debugged and tuned applications for companies such as eBay, Microsoft, AutoDesk, and everyone in between. As a 10 year MVP, John’s written countless articles and three books on debugging. Prior to starting Wintellect 14 years ago John was one of the earliest developers at the legendary debugging tools company, NuMega. He got a late start as a software developer after having spent five years as a paratrooper and Green Beret in the US Army."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.wintellect.com/Blogs" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/JohnWintellect" },
            new EpisodeLink() { Name = "Wintellect", Link = "http://www.wintellect.com" },
            new EpisodeLink() { Name = "WintellectNOW (with free two week promo code)", Link = "https://www.wintellectnow.com/Account/Promo/JOHNR-2013" },
          },
          GuestFirstMachineLink = "http://www.computinghistory.org.uk/det/24719/Zenith-Laptop-Computer-ZWL-183-92/",
          GuestFirstMachineName = "Zenith Z-183",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/z-183.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode27.mp3",
          YouTubeLink = "",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/06/02")
        },

        new Episode()
        {
          EpisodeNumber = 26,
          Blurb = new string[] 
          {
            "I've spent a lot of time creating XAML and MVVM models. Without Laurent Bugnion's great MVVM Library, I would have been stuck. I've admired his attitude and generosity for quite some time.",
            "In this episode of the Hello World Podcast I get to talk to Laurent about how he got started, how he works with UX people and how he got diverted from his first love of flying."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Laurent Bugnion",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/laurent-bugnion.jpg",
          GuestBio = new string[] 
          {
            "Laurent works as Senior Director for IdentityMine, one of the leading companies (and Gold Partner) for Microsoft technologies such as Windows Presentation Foundation, Silverlight, Pixelsense, Windows 8, Windows Phone, XBOX and generally User Experience. He is based in Zurich Switzerland, where he lives with his wife Chi Meei and his two daughters Alise and Laeticia.",
            "In October 2010, the book 'Silverlight 4 Unleashed' that he wrote was published at Sams, an advanced sequel to 'Silverlight 2 Unleashed' (published Oct 2008). He writes for MSDN magazine and other publications, codes in Windows Phone, Windows 8, WPF, Silverlight, ASP.NET and his blog is on http://blog.galasoft.ch. 2014 is his 8th year as a Microsoft Most Valuable Professional (Client Dev) and his second year as a Microsoft Regional Director. He is also the author of the well-known open source framework MVVM Light for Windows Phone, Windows 8, WPF, Silverlight."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Galasoft", Link = "http://www.galasoft.ch" },
            new EpisodeLink() { Name = "Blog", Link = "http://blog.galasoft.ch" },
            new EpisodeLink() { Name = "MVVM Light", Link = "http://www.mvvmlight.net" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Macintosh_LC",
          GuestFirstMachineName = "Macintosh LC II",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/mac-lc-ii.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode26.mp3",
          YouTubeLink = "",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/05/26")
        },
         
        new Episode()
        {
          EpisodeNumber = 25,
          Blurb = new string[] 
          {
            "Jon and I have known each other for a long time and we've had some of the most interesting conversations I can remember, mostly over an adult beverage or two. In this episode, I talk with Jon about his start and how lawyers might make the best developers. "
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jon Flanders",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jon-flanders.jpg",
          GuestBio = new string[] 
          {
            "Jon is most at home spelunking, trying to figure out how things work from the inside out. Jon is the author of RESTful.NET from O'Reilly, as well as Essential ASP for Addison-Wesley, and was a co-author of Mastering Visual Studio.NET for O'Reilly. Jon is currently helping companies build applications for the iPhone and iPad using iOS."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.jonflanders.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/jonflanders" },
            new EpisodeLink() { Name = "Pluralsight Courses", Link = "http://pluralsight.com/training/Authors/Details/jon-flanders" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Commodore_VIC20",
          GuestFirstMachineName = "Commodore Vic-20",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/vic20.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode25.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=sKLDoUEpx18",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/05/20")
        },

        new Episode()
        {
          EpisodeNumber = 24,
          Blurb = new string[] 
          {
            "As a former DevelopMentor employee and now a Pluralsight author, I of course know Fritz Onion. But to my surprise there was a lot I didn't know about him.",
            "In this episode, we talk about the nature of wanting to teach, early multi-processor OSs that he helped build in grad school, as well as why acoustic guitars are awesome. Take a listen!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Fritz Onion",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/fritz-onion.jpg",
          GuestBio = new string[] 
          {
            "Fritz is a co-founder of Pluralsight where he serves as the Chief Content Officer.",
            "Fritz is the author of the book 'Essential ASP.NET' published by Addison Wesley, available in both C# and Visual Basic .NET editions, and 'Essential ASP.NET 2.0'. He is a past columnist for MSDN Magazine, and and has spoken at many industry conferences including the PDC, TechEd, and VSLive!. Prior to .NET, Fritz's work focused on Windows development with C++ and COM, and has written several courses and many articles on C++, MFC, COM, and ATL. Microsoft recognized Fritz as an MVP for over 5 years for his contributions to the ASP.NET community.",
            "Fritz lives in central Maine."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://blog.pluralsight.com/author/fritzonion" },
            new EpisodeLink() { Name = "Pluralsight", Link = "http://pluralsight.com" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Macintosh_128K",
          GuestFirstMachineName = "Macintosh (128K)",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/mac-128k.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode24.mp3",
          YouTubeLink = "http://youtu.be/NXDLHPw0sHU",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/05/12")
        },

        new Episode()
        {
          EpisodeNumber = 23,
          Blurb = new string[] 
          {
            "This week I had Phil Haack on the show to talk about how he got started. As you probably already know, he was formerly on the ASP.NET team doing great work with MVC and other projects.",
            "I was able to ask him all the hard questions including when he changed his name to improve his stature in the development community. We also talked about his Coco computer, F# and how he's ended up doing desktop development at GitHub."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Phil Haack",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/phil-haack.jpg",
          GuestBio = new string[] 
          {
            "Phil Haack (yes, it's pronounced \"hack\") works at GitHub finding ways to make it better for .NET and Windows developers everywhere. Prior to GitHub, he was a senior Program Manager at Microsoft responsible for shipping ASP.NET MVC, NuGet, among other projects. These projects were released under open source licenses and helped served as examples of the open source model for shipping software to other teams at Microsoft.",
            "Phil is a co-author of the popular Professional ASP.NET MVC series and regularly speaks at conferences around the world. He's also made several appearances on technology podcasts such as .NET Rocks, Hanselminutes, Herding Code, and The Official jQuery Podcast."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://haacked.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/haacked" },
            new EpisodeLink() { Name = "GitHub", Link = "https://github.com/haacked" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80_Color_Computer",
          GuestFirstMachineName = "TRS-80 Color Computer",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80coco.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode23.mp3",
          YouTubeLink = "http://youtu.be/9B6t89MnemQ",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/05/05")
        },

        new Episode()
        {
          EpisodeNumber = 22,
          Blurb = new string[] 
          {
            "As a critical member of the ASP.NET team, I have always admired Brad Wilson's mix of pragmatism and humility. I was thrilled to find out he agreed to be on the podcast.",
            " In this week's episode we chat about early Commodore machines, what it is like to struggle to find the next job and the look our partner's have given us when we're playing MMOs. I think you'll really appreciate this one!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Brad Wilson",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/brad-wilson.jpg",
          GuestBio = new string[] 
          {
            "Brad Wilson has been a software professional for more than 20 years, working as a consultant, developer, team lead, architect, and CTO. He is probably best known for his work on ASP.NET MVC and ASP.NET Web API during his 7 1/2 year tenure at Microsoft. Today, he calls CenturyLink Cloud his home, where he is a Technical Director working on their worldwide Infrastructure-as-a-Service and cloud management platform. He also is an active open source contributor to xUnit.net and ElasticLINQ.",
            "In his off hours, he's an avid musician, poker player, and photographer."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/bradwilson" },
            new EpisodeLink() { Name = "Blog", Link = "http://bradwilson.typepad.com/" },
            new EpisodeLink() { Name = "Century Link Cloud", Link = "http://www.centurylinkcloud.com/" },
            new EpisodeLink() { Name = "xUnit.net", Link = "https://github.com/xunit/xunit" },
            new EpisodeLink() { Name = "ElasticLINQ", Link = "https://github.com/CenturyLinkCloud/ElasticLINQ" },
            new EpisodeLink() { Name = "500px", Link = "http://500px.com/bradwilson" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Commodore_PET",
          GuestFirstMachineName = "Commodore PET",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/commodore-pet.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode22.mp3",
          YouTubeLink = "http://youtu.be/aKIGtzz2n-k",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/04/28")
        },

        new Episode()
        {
          EpisodeNumber = 21,
          Blurb = new string[] 
          {
            "This week I'm interviewing the interviewer! I had the pleasure of getting to chat with Richard Campbell about how he got started and it's an interesting story about fulfilling customer needs instead of focusing on the cool-ness of the technology. I think you're really like this converstaion."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Richard Campbell",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/richard-campbell.jpg",
          GuestBio = new string[] 
          {
              "Richard Campbell has more than 30 years of high-tech experience and is both a Microsoft Regional Director and Microsoft Most Valuable Professional (MVP). He has consulted with a number of leading North American organizations; Barnes&Noble.com, Dow Chemical, Johnson & Johnson Health Care Services, Reuters, Subaru/Isuzu and the U.S. Air Force.", 
              "In addition to speaking at conferences around the world, Richard is co-host of '.NET Rocks!, the Internet Audio Talk Show for .NET Developers' and the host of 'RunAs Radio, the Internet Audio Talk Show for IT Professionals'."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = ".NET Rocks Podcast", Link = "http://www.dotnetrocks.com/" },
            new EpisodeLink() { Name = "RunAs Radio", Link = "http://www.runasradio.com/" },
            new EpisodeLink() { Name = "Twitter", Link = "https://twitter.com/richcampbell" },
            new EpisodeLink() { Name = "Humanitarian Toolbox", Link = "http://www.htbox.com" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80",
          GuestFirstMachineName = "TRS-80 Model 1",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80-m1.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode021.mp3",
          YouTubeLink = "http://youtu.be/zdAeGd2f21k",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/04/21")
        },

        new Episode()
        {
          EpisodeNumber = 20,
          Blurb = new string[] 
          {
            @"Scott Meyers wrote some of the most important C++ books in my library. As I fumbled through learning C++, his 
              observations on C++ helped shape my career and open many doors for me. I really enjoyed talking with Scott
              about how he got started, both in programming and with C++ to begin with. We even had a chance to talk about
              writing books and how we both enjoy that process."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Scott Meyers",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/scott-meyers.jpg",
          GuestBio = new string[] 
          {
            "Scott Meyers is one of the world's foremost authorities on C++.  He wrote the best-selling Effective C++ series (Effective C++, More Effective C++, and Effective STL); published and maintains the annotated training materials Overview of the New C++ (C++11/14) and Effective C++ in an Embedded Environment; is Consulting Editor for Addison Wesley's Effective Software Development Series, and, with Herb Sutter and Andrei Alexandrescu, is a principal in the conference-like event, C++ and Beyond. He has a Ph.D in Computer Science from Brown University.",  
            "Scott is currently working on a new book, Effective Modern C++: 40 Specific Ways to Improve Your Use of C++11 and C++14, which he desperately hopes to finish by summer."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Website", Link = "http://aristeia.com/" },
            new EpisodeLink() { Name = "Blog", Link = "http://scottmeyers.blogspot.com/" },
            new EpisodeLink() { Name = "His Books", Link = "http://www.aristeia.com/books.html" },
            new EpisodeLink() { Name = "C++ and Beyond", Link = "http://cppandbeyond.com/" },
          },
           GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Teleprinter",
          GuestFirstMachineName = "Teletype Printer",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/teletype.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode20.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=RZtFbDwJ0xc",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/04/14")
        },
        
        new Episode()
        {
          EpisodeNumber = 19,
          Blurb = new string[] 
          {
            "As an old ADO guy, my view of how databases were accessed was impacted by Bill Vaughn in a great way. When he agreed to be on the Podcast, I was delighted.",
            "In this episode we talk about his early days transitioning from Army helicopter pilot to working with a litany of groundbreaking companies including his time at Microsoft."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "William Vaughn",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/bill-vaughn.jpg",
          GuestBio = new string[] 
          {
            "William R. Vaughn is the former principal of Beta V Corporation and Microsoft MVP who worked at Microsoft for fourteen years. His previous books include seven editions of the popular Hitchhiker's Guides (Microsoft Press, Addison Wesley), ADO Examples and Best Practices, and the bestseller ADO.NET Examples and Best Practices and a separate edition for C# Programmers (APress). Bill is a top-rated speaker at conferences worldwide, including VBits, Developer Connections and TechEd, and is the author of numerous articles for SQL Server Magazine, MSDN Online, and others. He’s currently lecturing for Progressive Business Technology doing online webinars on SQL Server Reporting Services."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Tech Blog", Link = "http://betav.com/blog/billva" },
            new EpisodeLink() { Name = "Fiction Blog", Link = "http://betav.com/blog/fiction/" },
            new EpisodeLink() { Name = "Company", Link = "http://betav.com" },
            new EpisodeLink() { Name = "Books", Link = "http://theowlwrangler.com" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/RCA_Spectra_70#Model_70.2F46",
          GuestFirstMachineName = "RCA Spectra 70 Model 46",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/spectra-7046.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode19.mp3",
          YouTubeLink = "http://youtu.be/VV6Ik9FoXpI",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/04/07")
        },
        
        new Episode()
        {
          EpisodeNumber = 18,
          Blurb = new string[] 
          {
            "I ran into Lynn Langit at last year's Pluralsight Author Summit and had a good conversation about Big Data. When I started the Podcast, I knew she was someone I wanted to have on.",
            "Lynn's story is not typical and involves retail stores, project management and a dose of ADD. I think you'll enjoy this one!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Lynn Langit",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/lynn-langit.jpg",
          GuestBio = new string[] 
          {
            "Lynn is the Founder of Lynn Langit Consulting.  There she has been designing and helping teams to implement Big Data solutions.  These solutions have included SQL Server 2012, Hadoop, MongoDB, AWS, Windows Azure and Google Cloud technologies.",
            "In 2013 she was awarded the MVP for SQL Server from Microsoft.  In 2012, 2013 and again in 2014 she was recognized by Google for her community education work around their commercial cloud and received the Google Developer Expert award for the Google Cloud. She is the author of 3 books on SQL Server Business Intelligence (OLAP) the most recent of which is 'Smart Business Intelligence with SQL Server 2008' from MS Press. Lynn is also the author of many articles on BigData Technologies."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.lynnlangit.com" },
            new EpisodeLink() { Name = "YouTube Channel", Link = "http://www.youtube.com/SoCalDevGal" },
            new EpisodeLink() { Name = "Teaching Kids Programming", Link = "http://www.TeachingKidsProgramming.com" }
          },
          GuestFirstMachineLink = "http://www.pcmuseum.ca/details.asp?id=50",
          GuestFirstMachineName = "Compaq III",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/compaq-3.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode018.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=_xO5h50kApo",
          Length = new TimeSpan(0,47,0),
          PublishedDate = DateTime.Parse("2014/03/31")
        },
        
        new Episode()
        {
          EpisodeNumber = 17,
          Blurb = new string[] 
          {
            "Jim Wilson and I have had a lot of discussions about Android and Windows Phone. Discussions may be charitable. I love his sense of wonder and pragmatism. As a lover of mobile devices, Jim really understands what is important. Even back when we were both at DevelopMentor, it was clear to me that Jim had a lot of passion for software development. It's great to hear how it all got started.",
            "While we don't go at it over mobile platforms any more, it was nice to catch up with him at the recent Pluralsight Author Summit and talk about how he got started. You might be surprised how metal-shop and TRS-80's both contributed to his beginings."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jim Wilson",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jim-wilson.jpg",
          GuestBio = new string[] 
          {
            "Jim Wilson is president of JW Hedgehog, Inc., a consulting firm specializing in solutions for the Android, iOS, and Microsoft platforms. Jim has nearly 30 years of software engineering experience with the past 12 years heavily focused on creating mobile device and location-based solutions. After nearly a decade as a Microsoft Device Application Development MVP, Jim now focuses on developing Android and iOS device applications. Jim has authored over 30 articles on device application development, and has developed mobility and smart client curriculums for several organizations. Although based in New Hampshire, Jim and his wife spend as much time as possible at their place in Celebration, Florida (just 3 miles from Walt Disney World). Checkout Jim’s blog where he talks about a variety of mobile development issues as well as the fun of life just 3 miles from the Home of The Mouse."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://blog.jwhh.com" },
            new EpisodeLink() { Name = "Twitter", Link = "http://twitter.com/hedgehogjim" },
            new EpisodeLink() { Name = "Company", Link = "http://www.jwhedgehog.com/" },
            new EpisodeLink() { Name = "Pluralsight Courses", Link = "http://pluralsight.com/training/Authors/Details/jim-wilson" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80",
          GuestFirstMachineName = "TRS-80",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode17.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=PadqczzbJmA",
          Length = new TimeSpan(),
          PublishedDate = DateTime.Parse("2014/03/24")
        },

        new Episode()
        {
          EpisodeNumber = 16,
          Blurb = new string[] {"Like this week's guest, I have a passion for the Windows Phone. We don't agree on everything, but who could with a Dane who lives in Australia? Lars is a fellow Pluralsight author so I caught up with him at the recent Pluralsight Author Summit in Utah. Take a listen and see what you think."},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Lars Klint",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/lars-klint.jpg",
          GuestBio = new string[] {"Lars Klint suffers from split personality, as some would say. On the one hand he is a passionate programmer using the Microsoft Stack through .Net and C#. On the other hand he is a mad car guy. Lars loves to get his hands dirty and maintain his fleet of classic and off-road cars. When he is not in front of a phone, laptop, desktop or other gadget, he is out in the bush getting muddy or on a car club cruise. Lars has so far published two courses with Pluralsight: Building Windows Phone Apps that Stand Out and Windows Phone Testing and Error Management. As a frequent blogger, Lars has contributed articles to the Kiandra IT Blog, Nokia’s DVLUP portal and his own blog at klint.co, often presenting arguments that are not quite main stream, but with a dash of humour and a smidgen of cheekiness. If you want to ask Lars questions, suggest blog ideas, sell a car etc., shoot him an email or follow@larsklint on twitter."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://klint.co" },
            new EpisodeLink() { Name = "Pluralsight courses", Link = "http://pluralsight.com/training/Authors/Details/lars-klint"},
            new EpisodeLink() { Name = "Pluralsight Blog articles", Link = "http://blog.pluralsight.com/author/lars-klint"},
            new EpisodeLink() { Name = "Twitter page", Link = "https://twitter.com/larsklint"}
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/commodore_64",
          GuestFirstMachineName = "Commodore 64",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/c64.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode16.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=VmwzVkWMxR4",
          Length = new TimeSpan(0,34,0),
          PublishedDate = DateTime.Parse("2014/03/17")
        },
        
        new Episode()
        {
          EpisodeNumber = 15,
          Blurb = new string[] 
          {
            "You may know John Papa from Silverlight TV or his excellent Pluralsight courses. I've known John for many years. We seem to travel in the same circles technologically. He was one of the first calls I made when I started the podcast. ",
            "I finally was able to corral him at the Pluralsight Author Summit. I was surprised that he was the first of my guests to start off with a Commodore (like I did). He also had some very interesting comments about motivation and mentoring that I think most of us will share. Have a listen!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "John Papa",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/john-papa.jpg",
          GuestBio = new string[] {"John Papa is a well-known technology expert and is a former Evangelist for Microsoft on the Silverlight, Windows Phone and Windows 8 client teams. John is a Microsoft Regional Director and author of 100+ articles and 10 books, specializes in professional application development with technologies including HTML5, JavaScript, CSS, Angular, Durandal, Silverlight, WPF, C#, and .NET. He can often be found speaking around the world at keynotes and sessions for conferences such as Build, MIX, PDC, TechEd, VSLive and AngleBrackets. John was the host of the popular show Silverlight TV on Channel 9 and hosted many events including the MIXer and Open Source Fest at major conferences. He currently enjoys authoring courses for Pluralsight. You can always find John at johnpapa.net or on twitter at @john_papa."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://www.johnpapa.net/" },
            new EpisodeLink() { Name = "Pluralsight Videos", Link = "http://pluralsight.com/training/Authors/Details/john-papa" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/commodore_64",
          GuestFirstMachineName = "Commodore 64",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/c64.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode15.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=63-Q16MBNvo",
          Length = new TimeSpan(0, 38, 0),
          PublishedDate = DateTime.Parse("2014/03/10")
        },
        new Episode()
        {
          EpisodeNumber = 14,
          Blurb = new string[] {
            "Julie Lerman and I have known each other for long enough that neither of us is comfortable with how old that makes us feel. That's what makes this episode special. Julie and I take her back to her early years with computers and what it is like being an independent software developer for over 25 years. We chat about how being a woman in technology has affected her (or in many cases, not affected her).",
            "I hope you enjoy the episode. It was a pleasure to catch up with her!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Julie Lerman",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/julie-lerman.jpg",
          GuestBio = new string[] {"Julie Lerman is a Microsoft MVP, .NET mentor and consultant who lives in the hills of Vermont. You can find Julie presenting on Entity Framework and other Microsoft .NET topics at user groups and conferences around the world. Julie blogs at thedatafarm.com/blog, is the author of the highly acclaimed 'Programming Entity Framework' books, the MSDN Magazine Data Points column and popular videos on Pluralsight.com. Follow Julie on twitter at julielerman."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://thedatafarm.com/blog/" },
            new EpisodeLink() { Name = "Pluralsight Videos", Link = "http://pluralsight.com/training/Authors/Details/julie-lerman" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/HP-41",
          GuestFirstMachineName = "HP-41",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/hp-41.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode14.mp3",
          YouTubeLink = "https://www.youtube.com/watch?v=SpU5CZafXcc",
          Length = new TimeSpan(0, 38, 0),
          PublishedDate = DateTime.Parse("2014/03/05")
        },
        new Episode()
        {
          EpisodeNumber = 13,
          Blurb = new string[] 
          {
            "Many of you probably know this week's guest from his large collection of Pluralsight courses or heard his speak at conferences across the globe. I've always enjoyed his gentle manner and humility that lends itself so much to teaching technical content.",
            "In this episode, Scott shares with us about writing software to test chocolate, the complexity of real random numbers and his first experience with MIDI controllers on an Atari ST computer. I hope you enjoy it!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "K. Scott Allen",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/k-scott-allen.jpg",
          GuestBio = new string[] 
          {
            "Scott is a founder and Principal Consultant with OdeToCode LLC and the CTO at Medisolv Inc. He has 20+ years of commercial software development experience across a wide range of technologies. He’s successfully delivered software products for embedded, Windows, and web platforms. He’s also developed web services for Fortune 50 companies and firmware for startups.",
            "Scott is also a Pluralsight author, a host on the podcast Herding Code, written a few books, and spoken at conferences around the world."
          },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "His Website", Link = "http://odetocode.com/"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/OdeToCode"
            }
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Ti-99",
          GuestFirstMachineName = "TI-99",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ti99.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode13.mp3",
          YouTubeLink = "http://youtu.be/H_TmKV-vZPM",
          Length = new TimeSpan(0, 42,0),
          PublishedDate = DateTime.Parse("2014/02/24")
        },
        new Episode()
        {
          EpisodeNumber = 12,
          Blurb = new string[] {
            "Scott Hanselman joins me for the twelfth episode of the Hello World podcast. As many of my listeners, I too follow Scott on twitter and have been using it blog as a valuable resource for some time. I’ve always been impressed by his frankness when it comes to what technologies are valuable and which ones are not.",
            "In this episode we talk about a number of topics including being an A/V geek, what being a kid with a business card was like, and how it felt finishing his college degree."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Scott Hanselman",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/scott-hanselman.jpg",
          GuestBio = new string[] {"Scott is a web developer who has been blogging at http://hanselman.com for over a decade. He works in Open Source on ASP.NET and the Azure Cloud for Microsoft out of his home office in Portland, Oregon. Scott has three podcasts, http://hanselminutes.com for tech talk, http://thisdeveloperslife.com on developers' lives and loves, and http://ratchetandthegeek.com for pop culture and tech media. He's written a number of books and spoken in person to almost a half million developers worldwide."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://hanselman.com"
            },
            new EpisodeLink()
            {
              Name = "Hanselminutes Podcast", Link = "http://hanselminutes.com"
            },
            new EpisodeLink()
            {
              Name = "This Developer's Life Podcast", Link = "http://thisdeveloperslife.com"
            },
            new EpisodeLink()
            {
              Name = "Ratchet and the Geek Podcast", Link = "http://ratchetandthegeek.com"
            }
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Apple_II",
          GuestFirstMachineName = "Apple II",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/apple2.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode12.mp3",
          YouTubeLink = "http://youtu.be/jD_CtJDEPes",
          Length = new TimeSpan(0, 44, 0),
          PublishedDate = DateTime.Parse("2014/02/17")
        },
        new Episode()
        {
          EpisodeNumber = 11,
          Blurb = new string[] {"When I first asked Mary Jo Foley to be on the show, she told me she doesn't code. I wouldn't take no for an answer. The result? Hopefully it's great.", 
            "She takes us on a journey of what it takes to be a tech journalist. She talks about the first time she interviewed Bill Gates back when Microsoft employees numbered in the hundreds. I hope you like it!"},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Mary Jo Foley",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/mary-jo-foley.jpg",
          GuestBio = new string[] {"Mary Jo has covered the tech industry for 30 years for a variety of publications and Web sites, and is a frequent guest on radio, TV and podcasts, speaking about all things Microsoft-related. She is the author of Microsoft 2.0: How Microsoft plans to stay relevant in the post-Gates era (John Wiley & Sons, 2008). Her primary blog is at allaboutmicrosoft.com on ZDNet. She also is the cohost of the Windows Weekly podcast on TWiT"},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://allaboutmicrosoft.com"
            },
            new EpisodeLink()
            {
              Name = "TWiT", Link = "http://twit.tv/"
            }
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/CP/M",
          GuestFirstMachineName = "CP/M",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/generic-cpm.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode11.mp3",
          YouTubeLink = "http://youtu.be/iSN9t9HucCU",
          Length = new TimeSpan(0,35,0),
          PublishedDate = DateTime.Parse("2014/02/10")
        },
        new Episode()
        {
          EpisodeNumber = 10,
          Blurb = new string[] {"This week I get to chat with Michele about San Diego weather, WCF, and loving what we do for a living. I love her passion for the technology and clear-headedness about how careers are often not what we expect they'll be. I think you'll enjoy it too!"},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Michele Leroux Bustamante",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/michele-bustamante.jpg",
          GuestBio = new string[] {"Michele is a Managing Partner at Solliance, a Microsoft Regional Director and MVP.", 
            "With 20 years of experience designing and implementing enterprise systems, Michele has held senior executive positions at several corporations, has assembled software development teams and implemented processes for all aspects of the software development lifecycle, and facilitated many successful large-scale enterprise application deployments. Michele specializes in scalable and secure web application and services architecture, cloud-enabled applications and operations, and identity & access management. Michele is a frequent conference presenter and keynote speaker, has chaired many conferences and events, and has been published regularly in several technology journals. Michele’s books include her best selling book Learning WCF (O’Reilly, 2007/2009)."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://michelebusta.com"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "https://twitter.com/michelebusta"
            },
            new EpisodeLink()
            {
              Name = "Solliance", Link = "http://solliance.net"
            },
                        new EpisodeLink()
            {
              Name = "'Women. Tech. Love.' Podcast", Link = "http://www.womentechlove.com/"
            }

          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Pc_clone",
          GuestFirstMachineName = "PC Clone",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/pcclone.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode10.mp3",
          YouTubeLink = "http://youtu.be/hvD4_10IiD0",
          Length = new TimeSpan(0, 44, 0),
          PublishedDate = DateTime.Parse("2014/01/27")
        },
        new Episode()
        {
          EpisodeNumber = 9,
          Blurb = new string[] {"This week, I had the great fortune to speak to Glenn Block (of MEF, ScriptCS, and Web API fame). I was surprised by his path. I think you'll enjoy hearing how he got started."},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Glenn Block",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/glenn-block.jpg",
          GuestBio = new string[] {"Glenn is a product manager for Splunk's developer experience. In his spare time he is also the author and a maintainer of scriptcs, an OSS tool for C# scripting. A hardcore coder professionally for almost 20 years, he cares deeply about making developers' lives easier.  Previously Glenn worked at Microsoft where he kickstarted ASP.NET Web API and spearheaded Microsoft's node.js story on Azure. Glenn is an active contributor to  Node.js and .NET OSS projects, a supporter of the community, and a frequent speaker internationally on software development. He is also a bit of a Web API fanatic and author of a new OReilly book on the subject. He lives with his wife and daughter in Seattle where rain and caffeine are a plenty."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink() { Name = "Blog", Link = "http://codebetter.com/glennblock" },
            new EpisodeLink() { Name = "Book", Link = "http://www.amazon.com/Designing-Evolvable-Web-APIs-ASP-NET/dp/1449337716" },
            new EpisodeLink() { Name = "ScriptCS", Link = "http://scriptcs.net" },
            new EpisodeLink() { Name = "Radio Shack", Link = "http://www.radioshack.com/home/index.jsp" },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80",
          GuestFirstMachineName = "TRS-80",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode9.mp3",
          YouTubeLink = "http://youtu.be/4S4xwcIin1o",
          Length = new TimeSpan(0, 42,0),
          PublishedDate = DateTime.Parse("2014/01/21")
        },
        new Episode()
        {
          EpisodeNumber = 8,
          Blurb = new string[] {
            @"Is there much more to say than 'Charles Petzold'? As a luminary in software, I am honored to hear 
              his story. We talk about writing books, writing in PL/1 and what Windows 1.0 looked like. You're in
              for a treat if you are as indebted to his books on Windows development nearly as much as I am."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Charles Petzold",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/charles-petzold.jpg",
          GuestBio = new string[] { "Charles Petzold has been writing about Windows programming for over a quarter century, and his most recent book, Programming Windows, 6th Edition (Microsoft Press, 2012) takes on Windows 8. He is currently writing the DirectX Factor column for MSDN Magazine.",
                       "Petzold is also the author of two unique books that explore the foundations of digital computing: Code: The Hidden Language of Hardware and Software (Microsoft Press, 1999) and The Annotated Turing: A Guided Tour through Alan Turing’s Historic Paper on Computability and the Turing Machine (Wiley, 2008)."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://charlespetzold.com"
            },
            new EpisodeLink()
            {
              Name = "His Electronic Music", Link = "http://www.charlespetzold.com/etc/AdventuresInElectronicMusic/"
            },
            new EpisodeLink()
            {
              Name = "The Annotated Turing", Link = "http://www.theannotatedturing.com/"
            },
            new EpisodeLink()
            {
              Name = "Code: The Hidden Language of Computer Hardware and Software", Link = "http://www.charlespetzold.com/code/index.html"
            },
          },
          GuestFirstMachineLink = "https://en.wikipedia.org/wiki/PDP-10",
          GuestFirstMachineName = "PDP-10",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/pdp-10.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode8.mp3",
          YouTubeLink = "http://youtu.be/TM58YFP57vs",
          Length = new TimeSpan(0, 45, 44),
          PublishedDate = DateTime.Parse("2014/01/14")
        },
        new Episode()
        {
          EpisodeNumber = 7,
          Blurb = new string[] {
            @"As my old foe in the HTML v. Silverlight debate years ago, Hadi Hariri and I have been at odds before.
              But this time we don't argue at all but instead he tells us about how he begged to get 
              a CRC-464 as a young boy and ended up writing software for his community center."
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Hadi Hariri",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/hadi-hariri.jpg",
          GuestBio = new string[] { "Hadi a Software Developer, who currently works at JetBrains. His passions include Web Development and Software Architecture. He’s written a few books and has been speaking at conferences for over a decade, on things he’s passionate about."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://hadihariri.com"
            }
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Amstrad_CPC",
          GuestFirstMachineName = "Amstrad CPC-464",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/cpc464.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Episode7.mp3",
          YouTubeLink = "http://youtu.be/VZml9S2_ojU",
          Length = new TimeSpan(0,47,54),
          PublishedDate = DateTime.Parse("2014/01/06")
        },
        new Episode()
        {
          EpisodeNumber = 6,
          Blurb = new string[] {
            @"Ward Bell, well known for his wardrobe, is a great guest this week on the podcast. We talk about the ideas that
              shaped his early life as a developer. If you don't know what APL is or haven't had the experience to work
              with an IBM 360, this is the episode for you!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Ward Bell",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/ward-bell.jpg",
          GuestBio = new string[] {"Ward is a Microsoft MVP and the V.P. of Technology at IdeaBlade (www.ideablade.com), makers of the \"DevForce\" .NET application development product and BreezeJS. Ward often obsesses on client technologies for business applications, data access, and development practices." },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/wardbell"
            },
            new EpisodeLink()
            {
              Name = "BreezeJS", Link = "http://www.breezejs.com"
            },
            new EpisodeLink()
            {
              Name = "Idea Blade", Link = "https://www.ideablade.com/"
            },
            new EpisodeLink()
            {
              Name = "APL", Link = "http://en.wikipedia.org/wiki/APL_programming_language"
            },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/IBM_System/360",
          GuestFirstMachineName = "IBM 360 - via Selectric Typewriter",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/IBM360Selectric.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/EP006_WardBell.mp3",
          YouTubeLink = "http://youtu.be/bPQ9Sp501os",
          Length = new TimeSpan(0,44,0),
          PublishedDate = DateTime.Parse("2013/12/30")
        },
        new Episode()
        {
          EpisodeNumber = 5,
          Blurb = new string[] {""},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jesse Liberty",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jesse-liberty.jpg",
          GuestBio = new string[] {@"Jesse Liberty is a Master Consultant for <a href=""http://falafel.com/"">Falafel Software</a>, a <a href=""http://mvp.microsoft.com/en-us/mvp/Jesse%20Liberty-5000326"">Microsoft MVP</a>, a Telerik MVP, an <a href=""http://www.amazon.com/Jesse-Liberty/e/B000APP6I6/ref=sr_tc_2_0?qid=1359124796&amp;sr=1-2-ent"">author</a>, and he creates courses for <a href=""http://pluralsight.com/training"">Pluralsight</a>. Jesse hosts the popular <a href=""http://jesseliberty.com/podcast/"">Yet Another Podcast</a> and his <a href=""http://jesseliberty.com/"">blog</a> is considered required reading. He was a Senior Evangelist for Microsoft, a XAML Evangelist for Telerik, a Distinguished Software Engineer at AT&T; Software Architect for PBS and Vice President of Information Technology at Citibank. Jesse can be followed on twitter at <a href=""http://twitter.com/jesseliberty"">@JesseLiberty</a>"},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://jesseliberty.com"
            },
            new EpisodeLink()
            {
              Name = "Yet Another Podcast", Link = "http://jesseliberty.com/podcast"
            },
            new EpisodeLink()
            {
              Name = "Pluralsight Videos", Link = "http://pluralsight.com/training/Authors/Details/jesse-liberty"
            },
            new EpisodeLink()
            {
              Name = "Books", Link = "http://www.amazon.com/Jesse-Liberty/e/B000APP6I6/ref=sr_tc_2_0?qid=1379081450&sr=1-2-ent"
            },
            new EpisodeLink()
            {
              Name = "Felafel Software", Link = "http://www.falafel.com/"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://www.twitter.com/jesseliberty"
            },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Monroe_Calculator_Company",
          GuestFirstMachineName = "Monrobot",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/monrobot.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/FullEpisode5.mp3",
          YouTubeLink = "http://youtu.be/sWSl5e_nmzw",
          Length = new TimeSpan(0,38,24),
          PublishedDate = DateTime.Parse("2013/12/16")
        },
        new Episode()
        {
          EpisodeNumber = 4,
          Blurb = new string[] {
            @"If you ever expected to hear the phrases 'DirectX' and Air Force in the same sentence,
              you'll enjoy this episode!"
          },
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Brian Noyes",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/brian-noyes.jpg",
          GuestBio = new string[] {"Brian Noyes is a software architect, CTO of Solliance (www.solliance.net), Microsoft Regional Director, Microsoft MVP, and Pluralsight Author. Brian specializes in building rich client applications with XAML and HTML 5, as well as the services that back them with Web APIs and WCF Services. Brian has authored a number of books including Developers Guide to Microsoft Prism 4, Smart Client Deployment with ClickOnce, and Data Binding with Windows Forms 2.0, and speaks at conferences worldwide including Microsoft TechEd, VSLive!, DevIntersection, and others. Brian got started programming as a hobby while flying F-14 Tomcats in the U.S. Navy, later turning his passion for software into his current career. You can contact Brian on Twitter @briannoyes or through his blog http://briannoyes.net." },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://briannoyes.net"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/briannoyes"
            },
            new EpisodeLink()
            {
              Name = "Solliance", Link = "http://www.solliance.net"
            }

          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Programmed_Data_Processor",
          GuestFirstMachineName = "Mainframe (PDP)",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/vt100.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Final_004.mp3",
          YouTubeLink = "http://youtu.be/_0xPKW67E2k",
          Length = new TimeSpan(0,31,22),
          PublishedDate = DateTime.Parse("2013/12/09")
        },
        new Episode()
        {
          EpisodeNumber = 3,
          Blurb = new string[] 
          {
            @"Chris and I are long-time friends and hopefully it shows in this episode, recorded at the 
              MVP summit so the echo is an added benefit. If you ever sold a piece of software in a plastic 
              bag hung at your local computer shop, you'll enjoy this episode."},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Chris Sells",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/chris-sells.jpg",
          GuestBio = new string[] {"Chris Sells has a long history as a contributing member of the Windows developer community. He enjoys long walks on the beach and various computer technologies."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://sellsbrothers.com"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/csells"
            },
            new EpisodeLink()
            {
              Name = "Code Complete Book (Steve McConnel; Book - We had the wrong title)", Link = "http://www.amazon.com/Code-Complete-Practical-Handbook-Construction/dp/0735619670"
            },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Teleprinter",
          GuestFirstMachineName = "Teletype Printer",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/teletype.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/E003Final.mp3",
          YouTubeLink = "http://youtu.be/boqToRP5V0U",
          Length = new TimeSpan(0,38,40),
          PublishedDate = DateTime.Parse("2013/12/02")
        },
        new Episode()
        {
          EpisodeNumber = 2,
          Blurb = new string[] {"In this episode, Woody and I discuss what's it like starting out late into the development world."},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Chris Woodruff",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/chris-woodruff.jpg",
          GuestBio = new string[] {"Chris Woodruff (or Woody as he is commonly known as) has a degree in Computer Science from Michigan State University’s College of Engineering. Woody has been developing and architecting software solutions for almost 15 years and has worked in many different platforms and tools. He is a community leader, helping such events as Day of .NET Ann Arbor, West Michigan Day of .NET and CodeMash. He was also instrumental in bringing the popular Give Camp event to Western Michigan where technology professionals lend their time and development expertise to assist local non-profits. As a speaker and podcaster, Woody has spoken and discussed a variety of topics, including database design and open source. He is a Microsoft MVP in Visual C# and was recognized in 2010 as one of the top 20 MVPs world-wide."},
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://chriswoodruff.com"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/cwoodruff"
            },
            new EpisodeLink()
            {
              Name = "Podcast", Link = "http://deepfriedbytes.com"
            },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/TRS-80",
          GuestFirstMachineName = "TRS-80",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/trs80.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/Final_002.mp3",
          YouTubeLink = "http://youtu.be/ST_d0OcdeZQ",
          Length = new TimeSpan(0,24,00),
          PublishedDate = DateTime.Parse("2013/11/25")
        },
        new Episode()
        {
          EpisodeNumber = 1,
          Blurb = new string[] {"In this first episode, I stay local and talk with Atlanta legend Jeremy Likness about how he got started. We discuss the magical TI-99 and how Clipper used to be good!"},
          PodcastName = "hwpod",
          Status = EpisodeStatus.Live,
          GuestName = "Jeremy Likness",
          GuestHeadshot = "http://wildermuth.com/images/hwpod/jeremy-likness.jpg",
          GuestBio = new string[] {"Jeremy Likness is a principal consultant at Wintellect. He has 20 years of experience building enterprise applications and specializes in delivering web-based solutions using the Microsoft stack with client technologies like TypeScript and AngularJS. A 4-time Microsoft MVP, Jeremy is the author of several books that cover XAML technologies like Silverlight and Windows 8.1 and speaks frequently at user group events and conferences. Jeremy lives in Woodstock, GA with his wife, daughter, three dogs and an Ecclectus parrot. He loves hiking, running, skiing, shooting guns and shooting pool (9-ball is his favorite game). " },
          GuestLinks = new EpisodeLink[]
          {
            new EpisodeLink()
            {
              Name = "Blog", Link = "http://csharperimage.jeremylikness.com/"
            },
            new EpisodeLink()
            {
              Name = "Twitter", Link = "http://twitter.com/jeremylikness"
            },
            new EpisodeLink()
            {
              Name = "Book", Link = "http://bit.ly/winrtexample"
            },
          },
          GuestFirstMachineLink = "http://en.wikipedia.org/wiki/Ti-99",
          GuestFirstMachineName = "TI-99",
          GuestFirstMachine = "http://wildermuth.com/images/hwpod/ti99.jpg",
          AudioLink = "http://traffic.libsyn.com/hwpod/EP001-Final.mp3",
          YouTubeLink = "http://youtu.be/lhOhTE9bgbI",
          Length = new TimeSpan(0, 29, 57),
          PublishedDate = DateTime.Parse("2013/11/18")
        },
      });
    }
  }
}