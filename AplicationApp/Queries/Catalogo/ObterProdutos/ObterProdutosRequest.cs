using Ardalis.Result;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using JdMarketplace.App.Dtos;
using JdMarketplace.App.Dtos.Catalogo.Produto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutos
{
    public class ObterProdutosRequest : IRequest<Result<ObterProdutosResponse>>
    {
        public string Pesquisa { get; set; }
        public OrdenacaoCamposProdutosDto OrdenacaoCamposProdutosDto { get; set; }
        public OrdenacaoDto Ordenacao { get; set; }
        public int QuantidadeItens { get; set; }
        public int Pagina { get; set; }

    }
}
