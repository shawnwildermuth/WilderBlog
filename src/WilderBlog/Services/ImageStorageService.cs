using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WilderBlog.Config;

namespace WilderBlog.Services
{
  public class ImageStorageService : IImageStorageService
  {
    private readonly IOptions<AppSettings> _settings;
    private readonly ILogger<ImageStorageService> _logger;

    public ImageStorageService(IOptions<AppSettings> settings, ILogger<ImageStorageService> logger)
    {
      _settings = settings;
      _logger = logger;
    }

    public async Task<string> StoreImage(string path, byte[] image)
    {
      try
      {
        var filename = Path.GetFileName(path);

        var creds = new StorageSharedKeyCredential(_settings.Value.BlobStorage.Account, _settings.Value.BlobStorage.Key);
        var client = new BlobServiceClient(new Uri(_settings.Value.BlobStorage.StorageUrl), creds);
        var container = client.GetBlobContainerClient("img");
        var list = container.GetBlobs();
        var count = list.Count();

        var blob = container.GetBlobClient(filename);
        var url = blob.Uri.ToString();
        bool shouldUpload = true;
        if (await blob.ExistsAsync())
        {
          var props = await blob.GetPropertiesAsync();
          if (props.Value.ContentLength == image.Length)
          {
            shouldUpload = false;
          }
        }

        if (shouldUpload)
        {
          var stream = new MemoryStream(image);
          if (shouldUpload) await blob.UploadAsync(stream, true);
        }

        return url;
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to upload blob: {ex}");
        throw;
      }
    }
  }
}
