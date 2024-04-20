using Domain.Entity;
using ProAgil.Repository;
using System;

namespace JdMarketplace.App.Commands.Catalogo.CriarProduto
{
    public class CriarProdutoHandler : ICriarProdutoHandler
    {
        public readonly CatalogoContext _dataContext;

        public CriarProdutoHandler(CatalogoContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CriarProdutoResponse Handle(CriarProdutoRequest command)
        {
            try
            {
                var produto = Produto.Create(command.Nome, command.Descricao,
                                                    command.Observacao, command.Valor,
                                                    command.QuantidadeEmEstoque);

                _dataContext.Add(produto);
                var save = _dataContext.SaveChangesAsync();


                return new CriarProdutoResponse
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,

                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
