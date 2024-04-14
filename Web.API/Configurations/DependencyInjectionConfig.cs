using AplicationApp;
using AplicationApp.Interfaces;
using Domain.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Gererics;
using Infrastructure.Repository.Repositories;
using JdMarketplace.App.Commands;
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
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ICompraService, CompraService>();    
            services.AddScoped<IProduto, RepositoryProduto>();
            services.AddScoped<ICategoria, RepositoryCategoria>();
            services.AddScoped<ICompra, RepositoryCompra>();

            services.AddTransient<ICriarProdutoHandler, CriarProdutoHandler>();
            services.AddTransient<IObterProdutoPorIdHandler, ObterProdutoPorIdHandler>();
            services.AddTransient<IObterProdutosHandler, ObterProdutosHandler>();
        }
    }
}