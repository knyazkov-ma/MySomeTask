using System;

namespace MySomeTask.Loggers
{
  public interface ILoggerService
  {
    void LogError(Exception ex, string message);
  }
}
