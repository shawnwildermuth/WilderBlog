namespace WilderBlog.Data
{
  public class BaseRepository
  {
    protected int CalculatePages(int totalCount, int pageSize)
    {
      return ((int)(totalCount / pageSize)) + ((totalCount % pageSize) > 0 ? 1 : 0);
    }
  }
}