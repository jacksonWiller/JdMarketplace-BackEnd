using JdMarketplace.App.Dtos.Catalogo.Produto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JdMarketplace.App.Commands.Catalogo.EditarProduto
{
    public class EditarProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public string ImagemURL { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public bool Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public List<CategoriaDto> Categorias { get; set; }
    }
}
