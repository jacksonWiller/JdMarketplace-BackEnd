using Ardalis.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.EditarImagensProduto
{
    public class EditarImagensProdutoHandler : IRequestHandler<EditarImagensProdutoRequest, Result<EditarImagensProdutoResponse>>
    {
        public readonly CatalogoContext _dataContext;

        public EditarImagensProdutoHandler(CatalogoContext dataContext
            )
        {
            _dataContext = dataContext;
        }

        public async Task<Result<EditarImagensProdutoResponse>> Handle(EditarImagensProdutoRequest request,
            CancellationToken cancellationToken)
        {

            var produto = await _dataContext.Produtos.FirstOrDefaultAsync(x => x.Id == request.Id);

            produto.EditarImagens(
                request.ImagensUrl
            );

            _dataContext.Update(produto);
            var save = _dataContext.SaveChangesAsync();

            var response = new EditarImagensProdutoResponse()
            {
                Id = request.Id,
                ImagensUrl = request.ImagensUrl
            };

            return Result<EditarImagensProdutoResponse>.Success(
                response, "Imagens Alteradas com sucesso");

        }
    }

}
