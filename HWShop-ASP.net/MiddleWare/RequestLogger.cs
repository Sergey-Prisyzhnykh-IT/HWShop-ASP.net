using System.Text;

namespace BlazorApp.MiddleWare;

public class RequestLogger
{
    private readonly RequestDelegate requestDelegate;
    private readonly ILogger<RequestLogger> logger;

    public RequestLogger(RequestDelegate requestDelegate, ILogger<RequestLogger> logger)
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        httpContext.Request.EnableBuffering();

        LogHeaders(httpContext);

        httpContext.Request.Body.Position = 0;
        using (StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
        {
            string log = await reader.ReadToEndAsync();
            
            logger.LogInformation("Request body: {0}", log);
            httpContext.Request.Body.Position = 0;
        }

        await requestDelegate(httpContext);
    }

    private void LogHeaders(HttpContext context)
    {
        logger.LogInformation("Request headers: {0}", context.Request.Headers);
    }
}