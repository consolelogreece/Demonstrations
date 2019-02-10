using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public static class Structure
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // Code before "next", therefore operating on request.
                await context.Response.WriteAsync("Hello, World!\n"); // 1

                // await next middleware, still operating on the request.
                await next();

                // this code is after next, therefore operates on the response.
                await context.Response.WriteAsync("Have a nice day!\n"); // 3
            });

            app.Use(async (context, next) =>
            {
                // Operates on request.
                await context.Response.WriteAsync("This is a simple middleware demo,\n"); // 2
            });
        }
    }
}

