using Microsoft.AspNetCore.Builder;

namespace Middleware
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            Map.Configure(app);
            Run_vs_Use.Configure(app);
            Structure.Configure(app);
        }
    }
}
