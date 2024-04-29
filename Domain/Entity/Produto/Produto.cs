using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Domain.Entity.Notifications;
using Domain.Interfaces;

namespace Domain.Entity
{
    [Table("Produtos")]
    public class Produto : Base
    {
        [Key]
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }        
        public string Descricao { get; protected set; }
        public string Observacao { get; protected set; }
        public decimal Valor { get; protected set; }
        public string ImagemURL { get; set; }
        public int QuantidadeEmEstoque { get; protected set; }
        public virtual ICollection<ProdutosCategorias> ProdutosCategorias { get; protected set; }

        public void EditarImagens(string imagem)
        {
            ImagemURL = imagem.ToString();
        }

        public void EditarProduto(string nome, string descricao, string observacao, decimal valor, int quantidadeEmEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Observacao = observacao;
            Valor = valor;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        public static Produto CriarProduto(string nome, string descricao, string observacao, decimal valor,
                                        int quantidadeEmEstoque)
        {
            Produto produto = new Produto()
            {
                Nome = nome,
                Descricao = descricao,
                Observacao = observacao,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                Estado = true,
                DataDeCriacao = DateTime.Now,
                DataDeAlteracao = DateTime.Now,
            };

            return produto;
        }

        public static Produto CriarProduto(string nome, string descricao, string observacao, decimal valor, 
                                        int quantidadeEmEstoque, string imagemURL,
                                        ICollection<ProdutosCategorias> produtosCategorias)
        {
            return CriarProduto(Guid.NewGuid(), nome, descricao, observacao, valor, quantidadeEmEstoque, imagemURL, produtosCategorias);
        }
        public static Produto CriarProduto(Guid id, string nome, string descricao, string observacao, 
                                        decimal valor, int quantidadeEmEstoque, string imagemURL,
                                        ICollection<ProdutosCategorias> produtosCategorias)
        {
            Produto produto = new Produto()
            {
                Nome = nome,
                Descricao = descricao,
                Observacao = observacao,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                ImagemURL = imagemURL,
                Estado = true,
                DataDeCriacao = DateTime.Now,
                DataDeAlteracao = DateTime.Now,
                ProdutosCategorias = produtosCategorias
            }; 

            return produto;         
        }
    }    
}

