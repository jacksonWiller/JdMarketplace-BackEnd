using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;
using System;

namespace ProAgil.Repository
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base (options) {}
        public DbSet<Produto> Produtos {get;set;}
        public DbSet<Categoria> Categorias {get;set;}
        public DbSet<ProdutosCategorias> ProdutosCategorias {get;set;}
        public DbSet<Compra> Compras {get;set;}
        public DbSet<ItemPedido> ItemPedido {get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                 .ToTable("Catalogo_Produto");

            modelBuilder.Entity<ProdutosCategorias>()
                .ToTable("Catalogo_Categoria")
                .HasKey(PC => new {PC.ProdutoId, PC.CategoriaId});

            modelBuilder.Entity<ItemPedido>()
                .ToTable("Catalogo_Itens")
                .HasKey(PC => new {PC.ProdutoId, PC.CompraId});
        }
    }
}