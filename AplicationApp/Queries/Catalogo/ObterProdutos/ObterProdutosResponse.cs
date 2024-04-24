using JdMarketplace.App.Dtos.Catalogo.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutos
{
    public class ObterProdutosResponse
    {
        public List<ProdutoDto> Produtos { get; set; } = new List<ProdutoDto>();
        public int Total { get; set; }
        public int Pagina { get; set; }

    }
}
