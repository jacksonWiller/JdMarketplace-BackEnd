using Ardalis.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands.Catalogo.EditarImagensProduto
{
    public class EditarImagensProdutoRequest : IRequest<Result<EditarImagensProdutoResponse>>
    {
        public Guid Id { get; set; }
        public string ImagensUrl { get; set; }
    }
}
