using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using Shop.PublicApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Ardalis.Result;
using MediatR;
using JdMarketplace.Api.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using JdMarketplace.App.Commands.Catalogo.EditarProduto;
using JdMarketplace.App.Dtos.Catalogo.Produto;
using System.Collections.Generic;
using System.Linq;
using JdMarketplace.App.Queries.Catalogo.ObterProdutos;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoDetalhe;

namespace Web.Api.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IMediator _mediator;

        public ProdutoController(IWebHostEnvironment IWebHostEnviroment, IMediator mediator)
        {
            _hostEnviroment = IWebHostEnviroment;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Criar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<CriarProdutoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CriarProduto(
                       [FromBody] CriarProdutoRequest command
                   )
        {
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpPut]
        [Route("Editar")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<EditarProdutoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> EditarProduto(
                       [FromBody] EditarProdutoRequest command
                   )
        {
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("ObterTodos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<ObterProdutosResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ObterProdutos(
                       [FromQuery] ObterProdutosRequest command
        )
        {
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("ObterProdutoDetalhe")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<ObterProdutoDetalheResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ObterProdutoDetalhe(
                       [FromQuery] ObterProdutoDetalheRequest command
        )
        {
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("ListarOrdenacaoCampos")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<OrdenacaoCamposProdutosDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]

        public IActionResult ListarOrdenacaoCamposProduto()
        {
            var campos = Enum.GetNames(typeof(OrdenacaoCamposProdutosDto));
            var response = Result<IEnumerable<string>>.Success(campos);
            return Ok(response);
        }

    }
}