using AplicationApp.Dtos;
using ProAgil.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries
{
    public class ObterProdutosHandler : IObterProdutosHandler
    {
        public readonly DataContext _dataContext;

        public ObterProdutosHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ObterProdutosResponse> Handle(ObterProdutosRequest query)
        {
            try
            {
                var take = query.Quantidade;
                var skip = query.Quantidade * query.Pagina;
                var produtos = _dataContext.Produtos.Skip(skip).Take(take).ToList();

                var lista = new List<ProdutoDto>();

                foreach ( var produto in produtos )
                {
                    var produtoDto = new ProdutoDto()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Valor = produto.Valor
                    };
                    lista.Add( produtoDto );
                }

                var response = new ObterProdutosResponse() { Produtos = lista };
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
