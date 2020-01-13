namespace MySomeTask.Services
{
  public interface IPasswordService
  {
    string GetSha256Hash(string value);
  }
}
