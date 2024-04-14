using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId
{
    public interface IObterProdutoPorIdHandler
    {
        Task<ObterProdutoPorIdResponse> Handle(ObterProdutoPorIdRequest command);
    }
}
