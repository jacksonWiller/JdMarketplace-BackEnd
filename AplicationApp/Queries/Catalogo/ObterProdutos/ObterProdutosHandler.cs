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

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutos
{
    public class ObterProdutosHandler : IRequestHandler<ObterProdutosRequest, Result<ObterProdutosResponse>>
    {
        public readonly CatalogoContext _dataContext;

        public ObterProdutosHandler(CatalogoContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Result<ObterProdutosResponse>> Handle(ObterProdutosRequest request, CancellationToken cancellationToken)
        {

            IQueryable<Produto> query = _dataContext.Produtos;

            var totalProdutos = query.Count();

            //Aplicar filtro de pesquisa, se necessário
            if (!string.IsNullOrEmpty(request.Pesquisa))
            {
                var pesquisaLower = request.Pesquisa.ToLower();
                query = query.Where(p => p.Nome.ToLower().Contains(pesquisaLower) || p.Descricao.ToLower().Contains(pesquisaLower));
            }

            // Aplicar ordenação
            switch (request.OrdenacaoCamposProdutosDto)
            {
                case OrdenacaoCamposProdutosDto.Nome:
                    query = request.Ordenacao == OrdenacaoDto.Crescente ? query.OrderBy(p => p.Nome) : query.OrderByDescending(p => p.Nome);
                    break;
                case OrdenacaoCamposProdutosDto.Descricao:
                    query = request.Ordenacao == OrdenacaoDto.Crescente ? query.OrderBy(p => p.Descricao) : query.OrderByDescending(p => p.Descricao);
                    break;
                case OrdenacaoCamposProdutosDto.Valor:
                    query = request.Ordenacao == OrdenacaoDto.Crescente ? query.OrderBy(p => p.Valor.ToString()) : query.OrderByDescending(p => p.Valor.ToString());
                    break;
            }

            // Aplicar paginação
            var take = request.QuantidadeItens;
            var skip = request.QuantidadeItens * (request.Pagina);
            var produtos = query.Skip(skip).Take(take).ToList();


            var lista = new List<ProdutoDto>();

            foreach (var produto in produtos)
            {
                var produtoDto = new ProdutoDto()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Valor = produto.Valor,
                    ImagemURL = produto.ImagemURL,

                };
                lista.Add(produtoDto);
            }

            var response = new ObterProdutosResponse()
            {
                Produtos = lista,
                Pagina = request.Pagina,
                Total = totalProdutos,
            };
            return Result<ObterProdutosResponse>.Success(
            response); Result<ObterProdutosResponse>.Success(
            response);

        }
    }
}
