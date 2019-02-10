using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public static class Map
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.Map(new PathString("/Firstmap"), a => a.Run(async (context) =>
            {
                await context.Response.WriteAsync("First map\n");
            }));

            app.Map(new PathString("/Secondmap"), a => a.Run(async (context) =>
            {
                await context.Response.WriteAsync("Second map\n");
            }));


            app.Run(async context =>
            {
                await context.Response.WriteAsync("No alternate map path matched, so we landed here!\n");
            });
        }
    }
}
