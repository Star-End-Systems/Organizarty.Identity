using System.Net;
using Newtonsoft.Json;
using Organizarty.Domain.Exceptions;

namespace Organizarty.Identity.UI.Middlewares;

public class ErrorHandleMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger _logger;

    public ErrorHandleMiddleware(ILogger<ErrorHandleMiddleware> logger, RequestDelegate next)
    {
        this.next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationFailException e)
        {
            ErroLogger(e);

            context.Response.StatusCode = 400;

            var ers = e.Errors
                       .GroupBy(x => x.Field)
                       .Select(x => new
                       {
                           Field = x.Key,
                           Errors = x.Select(y => y.Message)
                       });

            var body = new
            {
                Message = e.Message,
                Errors = ers
            };

            await context.Response.WriteAsJsonAsync(body);
        }
        catch (NotFoundException e)
        {
            ErroLogger(e);

            context.Response.StatusCode = 404;

            await context.Response.WriteAsJsonAsync(new
            {
                Message = e.Message
            });
        }
        catch (Exception e)
        {
            ErroLogger(e);

            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                Message = "Something went wrong, try again later"
            });
        }
    }

    private void ErroLogger(Exception ex)
    {
        _logger.LogError(ex, JsonConvert.SerializeObject(new
        {
            Success = false,
            Message = ex.Message,
            Code = HttpStatusCode.BadRequest,
        }));

        // TODO: Automatically use when on non prod env. 
        // _logger.LogError(ex.StackTrace);
    }
}
