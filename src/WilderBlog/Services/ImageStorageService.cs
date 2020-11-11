using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WilderBlog.Config;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage;

namespace WilderBlog.Services
{
  public class ImageStorageService : IImageStorageService
  {
    private readonly IOptions<AppSettings> _settings;

    public ImageStorageService(IOptions<AppSettings> settings)
    {
      _settings = settings;
    }

    public async Task<string> StoreImage(string filename, byte[] image)
    {
      var filenameonly = Path.GetFileName(filename);

      var url = string.Concat(_settings.Value.BlobService.StorageUrl, filenameonly);

      var creds = new StorageSharedKeyCredential(_settings.Value.BlobService.Account, _settings.Value.BlobService.Key);
      var blob = new BlockBlobClient(new Uri(url), creds);

      bool shouldUpload = true;
      if (await blob.ExistsAsync())
      {
        var props = await blob.GetPropertiesAsync();
        if (props.Value.ContentLength == image.Length)
        {
          shouldUpload = false;
        }
      }

      var stream = new MemoryStream(image);
      if (shouldUpload) await blob.UploadAsync(stream);


      return url;
    }
  }
}
