using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entity;

namespace JdMarketplace.App.Dtos.Catalogo.Produto
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}