using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace MySomeTask.CommandHandlers
{
  /// <summary>
  /// Ожидаемое от CommandHandler исключение при ошибке/ошибках в бизнес-логике
  /// </summary>
  public class CommandHandlerException : Exception
  {
    /// <summary>
    /// Подробное описание ошибок, связанных со свойствами команды. 
    /// Свойство команды является ключем.
    /// </summary>
    public IDictionary<string, IList<string>> Details { get; private set; }
    public int HttpCode { get; set; } = 422;

    public CommandHandlerException(string message) : base(message)
    {
      
    }

    public CommandHandlerException(int httpCode, string message) : base(message)
    {
      HttpCode = httpCode;
    }

    public CommandHandlerException(string message, IDictionary<string, IList<string>> details) : this(message)
    {
      Details = details;
    }

    public static void ThrowIsNotValid(string message, ValidationResult validationResult)
    {
      if (validationResult.IsValid)
        return;

      var details = new Dictionary<string, IList<string>>();

      foreach (var error in validationResult.Errors)
      {
        if (details.ContainsKey(error.PropertyName))
          details[error.PropertyName].Add(error.ErrorMessage);
        else
          details[error.PropertyName] = new List<string> { error.ErrorMessage };
      }

      var ex = new CommandHandlerException(message, details);

      throw ex;
    }
  }
}
