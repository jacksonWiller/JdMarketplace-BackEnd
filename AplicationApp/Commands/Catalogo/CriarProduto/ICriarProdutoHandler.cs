using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.CriarProduto
{
    public interface ICriarProdutoHandler
    {
        CriarProdutoResponse Handle(CriarProdutoRequest command);
    }
}
