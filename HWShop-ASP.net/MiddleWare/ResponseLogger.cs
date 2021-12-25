using System.Text;

namespace BlazorApp.MiddleWare;

public class ResponseLogger
{
    private readonly RequestDelegate requestDelegate;
    private readonly ILogger<RequestLogger> logger;

    public ResponseLogger(RequestDelegate requestDelegate, ILogger<RequestLogger> logger)
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        Stream originalResponseBody = httpContext.Response.Body;
        using (MemoryStream replacementResponseBody = new MemoryStream())
        {
            httpContext.Response.Body = replacementResponseBody;

            await requestDelegate(httpContext);

            LogHeaders(httpContext);
            replacementResponseBody.Position = 0;

            await replacementResponseBody.CopyToAsync(originalResponseBody);
            httpContext.Response.Body = originalResponseBody;

            if (replacementResponseBody.CanRead)
            {
                replacementResponseBody.Position = 0;
                string log = await new StreamReader(replacementResponseBody, leaveOpen: true).ReadToEndAsync();
                logger.LogInformation("Response body {0}", log);
                replacementResponseBody.Position = 0;
            }
        }
    }

    private void LogHeaders(HttpContext context)
    {
        logger.LogInformation("Response headers: {0}", context.Response.Headers);     
    }
}