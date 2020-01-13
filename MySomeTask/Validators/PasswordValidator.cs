using FluentValidation;
using MySomeTask.Commands;
using MySomeTask.DataBase;
using System.Linq;

namespace MySomeTask.Validators
{
  public class PasswordValidator : AbstractValidator<string>
  {    
    public PasswordValidator()
    {
      
    }
  }
}
