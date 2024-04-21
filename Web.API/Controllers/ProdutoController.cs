using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId;
using JdMarketplace.App.Queries;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using Shop.PublicApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Ardalis.Result;
using MediatR;
using JdMarketplace.Api.Extensions;
using Microsoft.AspNetCore.Components.Forms;
using JdMarketplace.App.Commands.Catalogo.EditarProduto;

namespace Web.Api.Controllers
{

    [Route("api/[controller]")]
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

        //[HttpPost]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(ApiResponse<CriarProdutoResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Create([FromBody][Required] CreateCustomerCommand command) =>
        //(await _mediator.Send(command)).ToActionResult();

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

        //[HttpGet]
        //[Route("ObterPorId")]
        //public IActionResult ObterProdutoPorId(
        //    [FromServices] IObterProdutoPorIdHandler handler,
        //    [FromQuery] ObterProdutoPorIdRequest command
        //)
        //{
        //    var result = handler.Handle(command);
        //    return Ok(result);
        //}

        //[HttpGet]
        //[Route("ObterProdutos")]
        //public async Task<IActionResult> GetById(
        //    [FromServices] IObterProdutosHandler handler,
        //    [FromQuery] ObterProdutosRequest command
        //)
        //{
        //    var result = await handler.Handle(command);
        //    return Ok(result.Produtos);
        //}


        //[HttpDelete("{id}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        var produto = await _produtoService.GetProdutoAsyncById(id);
        //        if (produto == null) return NoContent();

        //        await _produtoService.DeleteProduto(id);
        //        return Ok(new { message = "Deletado" });              
        //            //    : throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
        //    }
        //    catch (Exception exeption)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Falha ao tentar remover o produto. Erro: {exeption.Message}");
        //    }
        //}

    }
}