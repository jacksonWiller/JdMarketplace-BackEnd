using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProAgil.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.CriarProduto
{
    public class CriarProdutoHandler : IRequestHandler<CriarProdutoRequest, Result<CriarProdutoResponse>>
    {
        public readonly CatalogoContext _dataContext;
        private readonly IValidator<CriarProdutoRequest> _validator;

        public CriarProdutoHandler(CatalogoContext dataContext,
            IValidator<CriarProdutoRequest> validator
            )
        {
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<Result<CriarProdutoResponse>> Handle(CriarProdutoRequest request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result<CriarProdutoResponse>.Invalid(validationResult.AsErrors());
            }

            var produto = Produto.CriarProduto(request.Nome, request.Descricao,
                                                   request.Observacao, request.Valor,
                                                   request.QuantidadeEmEstoque);

                _dataContext.Add(produto);
                var save = _dataContext.SaveChangesAsync();

                var response = new CriarProdutoResponse()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                };

                return Result<CriarProdutoResponse>.Success(
                response, "Produto adicionado com Sucesso!");
            }
        }

}
