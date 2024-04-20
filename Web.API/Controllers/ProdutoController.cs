using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId;
using JdMarketplace.App.Queries;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;

namespace Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostEnviroment;
        
        public ProdutoController(IWebHostEnvironment IWebHostEnviroment)
        {
            _hostEnviroment = IWebHostEnviroment;
        }

        [HttpPost]
        [Route("Criar")]
        public IActionResult CriarProduto(
                       [FromServices] ICriarProdutoHandler handler,
                       [FromBody] CriarProdutoRequest command
                   )
        {
            var response = handler.Handle(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterProdutoPorId(
            [FromServices] IObterProdutoPorIdHandler handler,
            [FromQuery] ObterProdutoPorIdRequest command
        )
        {
            var result = handler.Handle(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("ObterProdutos")]
        public async Task<IActionResult> GetById(
            [FromServices] IObterProdutosHandler handler,
            [FromQuery] ObterProdutosRequest command
        )
        {
            var result = await handler.Handle(command);
            return Ok(result.Produtos);
        }


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