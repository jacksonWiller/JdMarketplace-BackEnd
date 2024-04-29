using JdMarketplace.App.Dtos.Catalogo.Produto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JdMarketplace.App.Commands.Catalogo.EditarImagensProduto
{
    public class EditarImagensProdutoResponse
    {
        public Guid Id { get; set; }
        public string ImagensUrl { get; set; }
    }
}
