
using FluentValidation;
using JdMarketplace.App.Commands;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using JdMarketplace.App.Commands.Catalogo.EditarProduto;
using JdMarketplace.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ProAgil.Repository;
using System;
using System.IO;
using System.Reflection;
using Web.Api.Controllers;
using Web.API.Configuration;
using Web.API.Configurations;

namespace Web.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatalogoContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            //services.AddMediatR(typeof(CriarProdutoHandler).Assembly);
            //services.AddMediatR(typeof(EditarProdutoHandler).Assembly);

            services.AddMediatR(typeof(CriarProdutoHandler).Assembly, 
                typeof(EditarProdutoHandler).Assembly);

            services.AddTransient<IValidator<CriarProdutoRequest>, CriarProdutoValidator>();
            services.AddTransient<IValidator<EditarProdutoRequest>, EditarProdutoValidator>();

            services.AddValidatorsFromAssemblyContaining<CriarProdutoValidator>();

            services.AddIdentityConfiguration(Configuration);

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();

            services.AddDependencyInjectionConfiguration();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);

            app.UseCors(x => x.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin());

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

        }
    }
}
