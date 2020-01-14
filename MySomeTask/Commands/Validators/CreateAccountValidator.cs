using FluentValidation;
using MySomeTask.DataBase;
using MySomeTask.Validators;
using System.Linq;

namespace MySomeTask.Commands.Validators
{
  public class CreateAccountValidator : AbstractValidator<CreateAccount>
  {

    public CreateAccountValidator(AccountContext context)
    {

      RuleFor(cmd => cmd.Country)
                .NotEmpty()
                .MaximumLength(200)
                .Must((cmd, val) => context.Locations.Any(l => l.CountryName == cmd.Country))
                .WithMessage("Country must valid");

      RuleFor(cmd => cmd.Province)
                .NotEmpty()
                .MaximumLength(200)
                .Must((cmd, val) => context.Locations.Any(l => l.ProvinceName == cmd.Province))
                .WithMessage("Province must valid");
      
      RuleFor(cmd => cmd.Email).SetValidator(new MailValidator(context));
      RuleFor(cmd => cmd.Password).SetValidator(new PasswordValidator());

    }

  }
}
