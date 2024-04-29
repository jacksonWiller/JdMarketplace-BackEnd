using AplicationApp;
using Domain.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Gererics;
using Infrastructure.Repository.Repositories;
using JdMarketplace.Api.Service;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using JdMarketplace.App.Queries;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId;
using Microsoft.Extensions.DependencyInjection;

namespace Web.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGeneric<>));  
            services.AddScoped<IProduto, RepositoryProduto>();
            services.AddScoped<ICategoria, RepositoryCategoria>();
            services.AddScoped<ICompra, RepositoryCompra>();

            services.AddScoped<IImagemService, ImagemService>();
        }
    }
}