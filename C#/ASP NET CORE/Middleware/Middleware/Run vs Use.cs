using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public static class Run_vs_Use
    {
        public static void Configure(IApplicationBuilder app)
        {
            // app.Use accepts a context and a next delegate
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("This is 'Use'.");

                await next();
            });

            // app.Run only accepts a context.
            app.Run(async context =>
            {
                await context.Response.WriteAsync("\nThis is 'Run'.");
            });

            // As the last middleware was a 'Run', this middleware is never reached as it is not possible to call next() from a 'Run'.
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("\nThis is never called."); 
            });
        }
    }
}
