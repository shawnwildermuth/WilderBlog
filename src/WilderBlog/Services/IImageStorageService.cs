using System.Threading.Tasks;

namespace WilderBlog.Services
{
  public interface IImageStorageService
  {
    Task<string> StoreImage(string filename, byte[] image);
  }
}