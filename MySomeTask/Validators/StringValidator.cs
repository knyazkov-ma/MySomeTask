using System;
using System.Collections.Generic;
using MySomeTask.Extensions;

namespace MySomeTask.Validators
{
  public class StringValidator
  {

    private static class ErrorMessageResource
    {
      public const string EmptyString = "Значение не может быть пустым";
      public const string MaxLengthString = "Длина строки {0} не может превышать {1}";
      public const string MinLengthString = "Длина строки {0} не может быть меньше {1}";
    }

    public enum StringFormat
    {
      Email
    }

    public IDictionary<string, IEnumerable<string>> ErrorMessages { get; } = new Dictionary<string, IEnumerable<string>>();


    public bool CheckStringConstraint(string propName, string propValue, bool notEmpty, int maxLength, int minLength)
    {

      if (notEmpty)
      {
        if (propValue == null || propValue.Trim() == "")
        {
          SetMessages(propName, ErrorMessageResource.EmptyString);
          return false;
        }
        else if (propValue.Length > maxLength)
        {
          SetMessages(propName, String.Format(ErrorMessageResource.MaxLengthString, propValue.Length, maxLength));
          return false;
        }
        else if (minLength > 0 && propValue.Length < minLength)
        {
          SetMessages(propName, String.Format(ErrorMessageResource.MinLengthString, propValue.Length, minLength));
          return false;
        }
      }
      else
      {
        if (propValue != null && propValue.Trim() != "" && propValue.Length > maxLength)
        {
          SetMessages(propName, String.Format(ErrorMessageResource.MaxLengthString, propValue.Length, maxLength));
          return false;
        }
        else if (propValue != null && propValue.Trim() != "" && minLength > 0 && propValue.Length < minLength)
        {
          SetMessages(propName, String.Format(ErrorMessageResource.MinLengthString, propValue.Length, minLength));
          return false;
        }
      }

      return true;
    }

    public bool NormalizeAndCheckStringConstraint(string propName, ref string propValue, bool notEmpty, StringFormat stringFormat)
    {
      if (String.IsNullOrWhiteSpace(propValue))
      {
        if (notEmpty)
        {
          SetMessages(propName, ErrorMessageResource.EmptyString);
          return false;
        }
        else
          return true;
      }


      if (stringFormat == StringFormat.Email && !propValue.IsValidEmail())
      {
        SetMessages(propName, "Не верный формат Email");
        return false;
      }

      return true;
    }

    private void SetMessages(string key, string msg)
    {
      if (!ErrorMessages.Keys.Contains(key))
        ErrorMessages[key] = new List<string>();
      ((IList<string>)ErrorMessages[key]).Add(msg);
    }

  }
}
