using MySomeTask.CommandHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MySomeTask.Middlewares
{
  public class CommandHandlerExceptionMiddleware
  {
    private readonly RequestDelegate next;

    public CommandHandlerExceptionMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext context /* other dependencies */)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      if (exception is CommandHandlerException ex)
      {
        var result = JsonConvert.SerializeObject(new { errorMessage = ex.Message, errorDetails = ex.Details });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex.HttpCode;
        return context.Response.WriteAsync(result);
      }

      throw exception;
    }
  }

  // Extension method used to add the middleware to the HTTP request pipeline.
  public static class CommandHandlerExceptionMiddlewareExtensions
  {
    public static IApplicationBuilder UseCommandHandlerExceptionMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<CommandHandlerExceptionMiddleware>();
    }
  }
}
