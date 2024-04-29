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

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoDetalhe
{
    public class ObterProdutoDetalheRequest : IRequest<Result<ObterProdutoDetalheResponse>>
    {
        public Guid Id { get; set; }

        public ObterProdutoDetalheRequest(string id)
        {
            if (Guid.TryParse(id, out Guid parsedId))
            {
                Id = parsedId;
            }
            else
            {
                throw new ArgumentException("O valor fornecido não é um GUID válido.");
            }
        }

    }
}
