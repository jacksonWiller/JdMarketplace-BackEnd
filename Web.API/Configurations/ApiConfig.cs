using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            //adiciona a api 
            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // cors para  o ambiente de desenvolvimento
            app.UseCors("Development");

            // cors totalmente habilitado
            app.UseCors(option => option.AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityConfiguration();

            //para a aplicação aspnet reconheça todos os caminhos
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}