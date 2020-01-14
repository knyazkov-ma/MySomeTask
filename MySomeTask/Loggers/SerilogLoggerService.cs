using Serilog;
using System;

namespace MySomeTask.Loggers
{
  public class SerilogLoggerService : ILoggerService
  {
    public void LogError(Exception ex, string message)
    {
      Log.Error(ex, ex.Message);
    }
  }
}
