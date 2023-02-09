using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiToDo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS services to the services container.
            services.AddCors();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                // Allow requests from any origin.
                builder.AllowAnyOrigin();

                // Allow any method.
                builder.AllowAnyMethod();

                // Allow any header.
                builder.AllowAnyHeader();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
