using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WilderBlog.Config
{
  public class AppSettings
  {

    public WilderDbSettings WilderDb { get; set; }
    public ApplicationInsightsSettings ApplicationInsights { get; set; }
    public ExceptionsSettings Exceptions { get; set; }
    public DisqusSettings Disqus { get; set; }
    public MailServiceSettings MailService { get; set; }
    public MetaWeblogSettings MetaWeblog { get; set; }
    public AdServiceSettings AdService { get; set; }
    public GoogleSettings Google { get; set; }
    public BlobStorageSettings BlobStorage { get; set; }


    public class WilderDbSettings
    {
      public string OldConnectionString { get; set; }
      public string ConnectionString { get; set; }
      public bool TestData { get; set; }
    }

    public class ApplicationInsightsSettings
    {
      public string InstrumentationKey { get; set; }
    }

    public class ExceptionsSettings
    {
      public bool TestEmailExceptions { get; set; }
    }

    public class DisqusSettings
    {
      public string BlogName { get; set; }
    }

    public class MailServiceSettings
    {
      public string ApiKey { get; set; }
      public string ApiUser { get; set; }
      public string Receiver { get; set; }
      public bool TestInDev { get; set; }
    }

    public class MetaWeblogSettings
    {
      public string StoragePath { get; set; }
    }

    public class AdServiceSettings
    {
      public string Client { get; set; }
      public string Slot { get; set; }
    }

    public class GoogleSettings
    {
      public string Analytics { get; set; }
      public string CaptchaSecret { get; set; }
      public string CaptchaSiteId { get; set; }
    }

    public class BlobStorageSettings
    {
      public string Account { get; set; }
      public string Key { get; set; }
      public string StorageUrl { get; set; }
    }
  }
}
