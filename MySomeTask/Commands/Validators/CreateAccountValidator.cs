using FluentValidation;
using MySomeTask.DataBase;

namespace MySomeTask.Commands.Validators
{
  public class CreateAccountValidator : AbstractValidator<CreateAccount>
  {
    
    public CreateAccountValidator(AccountContext context)
    {
      
      //RuleFor(x => x.Country)
      //          .NotEmpty()
      //          .MaximumLength(200)
      //          .Must((cmd, val) => context.Locations.Any(l => l.CountryName == cmd.Country))
      //          .WithMessage(CoreStrings.EntityPropertyNotUnique);

      //RuleFor(x => x.ShortName)
      //    .Must((dto, value) => session.IsUniqueStringProperty<ContractType>(x => x.ShortName, value, dto.Id))
      //    .WithMessage(CoreStrings.EntityPropertyNotUnique)
      //    .When(x => !string.IsNullOrEmpty(x.ShortName));
    }

  }
}
