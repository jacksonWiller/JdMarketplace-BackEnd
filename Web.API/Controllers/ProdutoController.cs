using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using Shop.PublicApi.Models;
using Ardalis.Result;
using MediatR;
using JdMarketplace.Api.Extensions;
using JdMarketplace.App.Commands.Catalogo.EditarProduto;
using JdMarketplace.App.Dtos.Catalogo.Produto;
using System.Collections.Generic;
using JdMarketplace.App.Queries.Catalogo.ObterProdutos;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoDetalhe;
using JdMarketplace.App.Commands.Catalogo.EditarImagensProduto;
using JdMarketplace.Api.Service;

namespace Web.Api.Controllers
{

    [Route("api/produto/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnviroment;
        private readonly IMediator _mediator;
        private readonly IImagemService _imagemService;

        public ProdutoController(IWebHostEnvironment IWebHostEnviroment, IMediator mediator, IImagemService imagemService)
        {
            _hostEnviroment = IWebHostEnviroment;
            _mediator = mediator;
            _imagemService = imagemService;
        }

        [HttpPost]
        [Route("criar")]
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
        [Route("editar")]
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
        [Route("obter-todos")]
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
        [Route("obter-produto-detalhe/{produtoId}")]
        [ProducesResponseType(typeof(ApiResponse<ObterProdutoDetalheResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterProdutoDetalhe(
                       [FromRoute] string produtoId
        )
        {
            var query = new ObterProdutoDetalheRequest(produtoId);
            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }

        [HttpGet]
        [Route("listar-ordenacao-campos-produto")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<OrdenacaoCamposProdutosDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult ListarOrdenacaoCamposProduto()
        {
            var response = Enum.GetNames(typeof(OrdenacaoCamposProdutosDto));
            return Ok(response);
        }

        [HttpPut("editar-imagens-produto/{produtoId}")]
        public async Task<IActionResult> EditarImagemProduto(
            [FromRoute] Guid produtoId,
            IFormFile file
         )
        {

            var imagemUrl = await _imagemService.SalvarImagem(file);
            var command = new EditarImagensProdutoRequest()
            {
                Id = produtoId,
                ImagensUrl = imagemUrl
            };

            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

    }
}