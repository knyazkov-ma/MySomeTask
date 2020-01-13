namespace MySomeTask.Extensions
{
  /// <summary>
  /// Расширения для работы со строками
  /// </summary>
  public static class StringExtensions
  {
    

    /// <summary>
    /// Проверка является ли строка валидным E-mail
    /// </summary>        
    public static bool IsValidEmail(this string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
      }
      catch
      {
        return false;
      }
    }
  }
}
