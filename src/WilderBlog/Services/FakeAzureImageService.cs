using System.IO;
using System.Threading.Tasks;
using WilderMinds.AzureImageStorageService;

namespace WilderBlog.Services
{
  public class FakeAzureImageService : IAzureImageStorageService
  {
    public Task<ImageResponse> StoreImage(string containerName, string storageImagePath, Stream imageStream)
    {
      return Task.FromResult(new ImageResponse() { Success = true });
    }

    public Task<ImageResponse> StoreImage(string containerName, string storeImagePath, byte[] imageData)
    {
      return Task.FromResult(new ImageResponse() { Success = true });
    }
  }
}
