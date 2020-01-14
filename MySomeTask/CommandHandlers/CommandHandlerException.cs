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
    public IDictionary<string, IEnumerable<string>> Details { get; private set; }
    public int HttpCode { get; private set; }

    public CommandHandlerException(string message) : base(message)
    {
      HttpCode = 422;
    }

    public CommandHandlerException(int httpCode, string message) : base(message)
    {
      HttpCode = httpCode;
    }

    public CommandHandlerException(string message, IDictionary<string, IEnumerable<string>> details) : this(message)
    {
      Details = details;
    }

    public static void Throw(ValidationResult validationResult)
    {
      var ex = new CommandHandlerException(null);
      throw ex;
    }
  }
}
