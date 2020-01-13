namespace MySomeTask.Commands
{

  /// <summary>
  /// Создание учетной записи пользователя
  /// </summary>
  public class CreateAccount : Command
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public string Country { get; set; }    
    public string Province { get; set; }
    public string IP { get; set; }

  }
}
