using Ardalis.Result;
using Domain.Entity;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using JdMarketplace.App.Dtos;
using JdMarketplace.App.Dtos.Catalogo.Produto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoDetalhe
{
    public class ObterProdutoDetalheHandler : IRequestHandler<ObterProdutoDetalheRequest, Result<ObterProdutoDetalheResponse>>
    {
        public readonly CatalogoContext _dataContext;

        public ObterProdutoDetalheHandler(CatalogoContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Result<ObterProdutoDetalheResponse>> Handle(ObterProdutoDetalheRequest request, CancellationToken cancellationToken)
        {

            var produto = _dataContext.Produtos.Find(request.Id);

            var response = new ObterProdutoDetalheResponse()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Valor = produto.Valor
            };
            return Result<ObterProdutoDetalheResponse>.Success(
            response);
        }
    }
}
