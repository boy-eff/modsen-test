using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace ModsenEventService.API.Extensions;

public static class WebApplicationExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature != null)
                { 
                    await context.Response.WriteAsync(JsonSerializer.Serialize( "Internal server error"));
                }
            });
        });
    }
}