namespace WilderBlog.Services
{
  public class SpamState
  {
    public bool Success { get; internal set; }
    public object? Reason { get; internal set; }
  }
}