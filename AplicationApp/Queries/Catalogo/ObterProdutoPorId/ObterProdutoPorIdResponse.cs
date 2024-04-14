using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId
{
    public class ObterProdutoPorIdResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

    }
}
