using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Dtos
{
    public class Paginacao<T>
    {
        public IEnumerable<T> Itens { get; }
        public int QuantidadeTotal { get; }
        public int NumeroPagina { get; }
        public int TamanhoPagina { get; }

        public Paginacao(IEnumerable<T> itens, int quantidadeTotal, int numeroPagina, int tamanhoPagina)
        {
            Itens = itens;
            QuantidadeTotal = quantidadeTotal;
            NumeroPagina = numeroPagina;
            TamanhoPagina = tamanhoPagina;
        }
    }
}
