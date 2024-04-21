using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Domain.Entity;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.EditarProduto
{
    public class EditarProdutoHandler : IRequestHandler<EditarProdutoRequest, Result<EditarProdutoResponse>>
    {
        public readonly CatalogoContext _dataContext;
        private readonly IValidator<EditarProdutoRequest> _validator;

        public EditarProdutoHandler(CatalogoContext dataContext,
            IValidator<EditarProdutoRequest> validator
            )
        {
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<Result<EditarProdutoResponse>> Handle(EditarProdutoRequest request,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result<EditarProdutoResponse>.Invalid(validationResult.AsErrors());
            }

            var produto = await _dataContext.Produtos.FirstOrDefaultAsync(x => x.Id == request.Id);

            produto.EditarProduto(
                request.Nome,
                request.Descricao,
                request.Observacao,
                request.Valor,
                request.QuantidadeEmEstoque
            );

            _dataContext.Update(produto);
            var save = _dataContext.SaveChangesAsync();

            return Result.SuccessWithMessage("Updated successfully!");
        }
    }

}
