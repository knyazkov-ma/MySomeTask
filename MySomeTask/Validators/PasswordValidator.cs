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
      var pattern = @"[A-Z]+|\d+";      
      return Regex.IsMatch(email, pattern);
    }

    public PasswordValidator()
    {
      RuleFor(password => password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(15)
                .Must((password, val) => IsValid(password))
                  .WithMessage("Password must valid");
                
    }
  }
}
