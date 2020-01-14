using MySomeTask.CommandHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using MySomeTask.Loggers;

namespace MySomeTask.Middlewares
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
      var loggerService = (ILoggerService)httpContext.RequestServices.GetService(typeof(ILoggerService));

      try
      {
        // todo, add exception handler that will logs errors and raise needed exception 500 or 400
        await _next(httpContext);
      }
      catch (Exception ex)
      {
        if (ex is CommandHandlerException)
          return;

        loggerService.LogError(ex, ex.Message);
        throw;
      }
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class ExceptionMiddlewareExtensions
  {
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ExceptionMiddleware>();
    }
  }
}
