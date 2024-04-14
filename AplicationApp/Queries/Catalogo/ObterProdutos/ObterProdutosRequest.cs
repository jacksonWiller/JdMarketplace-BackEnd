using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries
{
    public class ObterProdutosRequest
    {
        public int Quantidade { get; set; }
        public int Pagina  { get; set; }
    }
}
