using AplicationApp.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.API.Models.Produto
{
    public class CriarProdutoViewModel
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

        public IFormFile Imagem { get; set; }
        public string ImagemURL { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public List<Guid> IdsCategoria { get; set; }
    }
}
