using FluentValidation;
using MySomeTask.Commands;
using MySomeTask.DataBase;
using System.Linq;

namespace MySomeTask.Validators
{
  public class MailValidator : AbstractValidator<string>
  {
    
    public MailValidator(AccountContext context)
    {
      
    }
  }
}
