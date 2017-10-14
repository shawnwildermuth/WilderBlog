using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WilderBlog.Services
{
  public class ImageStorageService : IImageStorageService
  {
    private readonly IConfiguration _config;

    public ImageStorageService(IConfiguration config)
    {
      _config = config;
    }

    public async Task<string> StoreImage(string filename, byte[] image)
    {
      var filenameonly = Path.GetFileName(filename);

      var url = string.Concat(_config["BlobService:StorageUrl"], filenameonly);

      var creds = new StorageCredentials(_config["BlobStorage:Account"], _config["BlobStorage:Key"]);
      var blob = new CloudBlockBlob(new Uri(url), creds);

      bool shouldUpload = true;
      if (await blob.ExistsAsync())
      {
        await blob.FetchAttributesAsync();
        if (blob.Properties.Length == image.Length)
        {
          shouldUpload = false;
        }
      }

      if (shouldUpload) await blob.UploadFromByteArrayAsync(image, 0, image.Length);


      return url;
    }
  }
}
