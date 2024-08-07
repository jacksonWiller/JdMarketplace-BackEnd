﻿using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.CriarProduto
{
    public class CriarProdutoRequest : IRequest<Result<CriarProdutoResponse>>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public List<Guid> IdsCategoria { get; set; }
    }
}
