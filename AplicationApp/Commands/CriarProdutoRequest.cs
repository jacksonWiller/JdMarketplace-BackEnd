﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands
{
    public class CriarProdutoRequest
    {
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(20, MinimumLength = 3,
        //ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(50, MinimumLength = 3,
        //ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Descricao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(50, MinimumLength = 3,
        //ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Observacao { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
        public decimal Valor { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[Range(1, 200, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]

        public int QuantidadeEmEstoque { get; set; }
        public List<Guid> IdsCategoria { get; set; }
    }
}