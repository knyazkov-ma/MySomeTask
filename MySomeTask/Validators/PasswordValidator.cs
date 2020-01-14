using FluentValidation;
using System.Text.RegularExpressions;

namespace MySomeTask.Validators
{
  public class PasswordValidator : AbstractValidator<string>
  {
    /// <summary>
    /// Проверка является ли строка валидным паролем
    /// </summary>        
    private bool IsValid(string email)
    {
      var pattern = @"[0-9]+[A-Za-z]+|[A-Za-z]+[0-9]+";      
      return Regex.IsMatch(email, pattern);
    }

    public PasswordValidator()
    {
      RuleFor(password => password)
                .NotEmpty()
                .MinimumLength(6)
                  .WithMessage("Password min 6 chars")
                .MaximumLength(15)
                  .WithMessage("Password max 15 chars")
                .Must((password, val) => IsValid(password))
                  .WithMessage("Password must contain min 1 digit and min 1 letter");
                
    }
  }
}
