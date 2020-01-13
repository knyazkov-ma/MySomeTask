using System.Security.Cryptography;
using System.Text;

namespace MySomeTask.Services
{
  public class PasswordService: IPasswordService
  {
    /// <summary>
    /// SHA256 хэш строки
    /// </summary>
    public string GetSha256Hash(string value)
    {
      var sb = new StringBuilder();

      using (var hash = SHA256.Create())
      {
        var enc = Encoding.UTF8;
        var result = hash.ComputeHash(enc.GetBytes(value));

        foreach (var b in result)
          sb.Append(b.ToString("x2"));
      }

      return sb.ToString();
    }
  }
}
