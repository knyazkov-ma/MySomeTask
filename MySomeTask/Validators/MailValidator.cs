using FluentValidation;
using MySomeTask.DataBase;
using System.Linq;

namespace MySomeTask.Validators
{
  public class MailValidator : AbstractValidator<string>
  {

    /// <summary>
    /// Проверка является ли строка валидным E-mail
    /// </summary>        
    private bool IsValid(string email)
    {
      try
      {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address.ToLower() == email.ToLower();
      }
      catch
      {
        return false;
      }
    }

    public MailValidator(AccountContext context)
    {
      RuleFor(email => email)
                .NotEmpty()
                .MaximumLength(128)
                .Must((email, val) => IsValid(email))
                  .WithMessage("E-mail must valid")
                .Must((email, val) => !context.Accounts.Any(a => a.Email == email))
                  .WithMessage("E-mail must be unique");
    }
  }
}
