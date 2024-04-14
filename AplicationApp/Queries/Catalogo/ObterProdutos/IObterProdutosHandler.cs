using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries
{
    public interface IObterProdutosHandler
    {
        Task<ObterProdutosResponse> Handle(ObterProdutosRequest command);
    }
}
