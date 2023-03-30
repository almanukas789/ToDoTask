using Microsoft.EntityFrameworkCore;
using WebApiToDo.Repository;
using WebApiToDo.Service;
using Microsoft.Extensions.Configuration;


namespace WebApiToDo
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services.AddTransient<IWebApiToDoRepository, WebApiToDoRepository>();

            services.AddTransient<IWebApiToDoService, WebApiToDoService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();

                builder.AllowAnyMethod();

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
