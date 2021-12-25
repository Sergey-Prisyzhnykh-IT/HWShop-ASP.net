using Microsoft.Net.Http.Headers;
using UAParser;

namespace BlazorApp.MiddleWare;

public static class CheckBrowser
{
    private static readonly List<string> correctBrowser = new List<string>() {"Edge"};

    public static async Task CheckerBrowser(HttpContext context, RequestDelegate next)
    {
        var browser = Parser.GetDefault().Parse(context.Request.Headers[HeaderNames.UserAgent]).UA.Family;
        if (!correctBrowser.Contains(browser))
        {
            await context.Response.WriteAsync($"Your browser is not supported :(, please use Edge Browser ");
            return;
        }
    
        await next(context);
    }
}