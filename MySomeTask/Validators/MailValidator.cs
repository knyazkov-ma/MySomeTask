using FluentValidation;
using MySomeTask.DataBase;

namespace MySomeTask.Validators
{
  public class MailValidator : AbstractValidator<string>
  {
    
    public MailValidator(AccountContext context)
    {
      
    }
  }
}
