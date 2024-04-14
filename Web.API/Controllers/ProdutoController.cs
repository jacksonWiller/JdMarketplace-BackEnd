using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AplicationApp.Interfaces;
using AplicationApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Web.API.Models.Produto;
using Domain.Entity;
using System.Collections.Generic;
using Web.API.Configurations;
using JdMarketplace.App.Commands;
using JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId;
using JdMarketplace.App.Queries;

namespace Web.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        private readonly IWebHostEnvironment _hostEnviroment;
        
        public ProdutoController(IProdutoService produtoService, IWebHostEnvironment IWebHostEnviroment)
        {
            _produtoService = produtoService;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync();
                if (produtos == null) return NoContent();
                return Ok(produtos);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter so produtos. Erro: {exeption.Message}");
            }
        }

        [HttpGet("{ProdutosId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid ProdutosId)
        {
            try
            {
                var produto = await _produtoService.GetProdutoAsyncById(ProdutosId);

                return Ok(produto);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter o Produtos por Id. Erro: {exeption.Message}");
            }
        }

        [HttpGet("{nome}/nome")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var produto = await _produtoService.GetAllProdutosAsyncByNome(nome);

                return Ok(produto);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar obter o produto por nome. Erro: {exeption.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoViewModel criarProdutoViewModel)
        {
            try
            {
                

                var produtoDto = new ProdutoDto
                {
                    Nome = criarProdutoViewModel.Nome ?? string.Empty,
                    Descricao = criarProdutoViewModel.Descricao ?? string.Empty,
                    Observacao = criarProdutoViewModel.Observacao ?? string.Empty,
                    Valor = criarProdutoViewModel.Valor,
                    QuantidadeEmEstoque = criarProdutoViewModel.QuantidadeEmEstoque,
                    Categorias = criarProdutoViewModel.IdsCategoria?.Select(id => new CategoriaDto { Id = id })?.ToList() ?? new List<CategoriaDto>()

                };

                var retorno = await _produtoService.AddProduto(produtoDto);
                return Ok(retorno);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar adicionar o produto. Erro: {exeption.Message}");
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Post([FromForm] CriarProdutoViewModel criarProdutoViewModel)
        //{
        //    try
        //    {
        //        // var produto = Request.Form.Files[0]; 
        //        // var file  = Request.Form.Files[0];
        //        // Console.Write("||||||||||||||||||||||||||||||||||||||||||");
        //        //  Console.WriteLine(produto.Imagem);
        //        //  Console.WriteLine(file);

        //        if(produto.Imagem != null){
        //            produto.ImagemURL = await SaveImage(produto.Imagem);
        //        }

        //        var retorno = await _produtoService.AddProduto(produto);
        //        return Ok(retorno);
        //    }
        //    catch (Exception exeption)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Falha ao tentar adicionar o produto. Erro: {exeption.Message}");
        //    }
        //}

        [HttpPost("add-image")]
        [AllowAnonymous]
        public async Task<IActionResult> PostProdutoImage(IFormFile file)
        {
            try
            {
                // var file = Request.Form.Files[0];
                // Console.Write("|||||||||||||||||||||||||||||||||||||||||||||||");
                // Console.WriteLine(file);
                
                if (file.Length > 0)
                {
                    // DeleteImagem(produto.ImagemURL);
                    // produto.ImagemURL = await SaveImage(file);
                }
                
                // var retorno = await _produtoService.AddProduto(produto);

                return Ok();
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar adicionar o produto. Erro: {exeption.Message}");
            }
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(Guid id, ProdutoDto model)
        {
            try
            {
                var evento = await _produtoService.UpdateProduto(id, model);
                if (evento == null) return NoContent();

                return Ok(evento);
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar atualizar o produto. Erro: {exeption.Message}");
            }
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoAsyncById(id);
                if (produto == null) return NoContent();

                await _produtoService.DeleteProduto(id);
                return Ok(new { message = "Deletado" });              
                    //    : throw new Exception("Ocorreu um problem não específico ao tentar deletar Evento.");
            }
            catch (Exception exeption)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Falha ao tentar remover o produto. Erro: {exeption.Message}");
            }
        }


        [HttpPut("upload-image/{produtoId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadImage(Guid produtoId)
        {
            try
            {
                var produto = await _produtoService.GetProdutoAsyncById(produtoId);

                var file = Request.Form.Files[0];
                Console.Write("|||||||||||||||||||||||||||||||||||||||||||||||");
                Console.WriteLine(file);
                
                if (file.Length > 0)
                {
                    // DeleteImagem(produto.ImagemURL);
                    // produto.ImagemURL = await SaveImage(file);
                }
                
                var ProdutoRetorno = await _produtoService.UpdateProduto(produtoId, produto);
      
                return Ok(ProdutoRetorno);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $" {ex.Message}");
            }

        }

        // [HttpPost("upload-image2")]
        // [AllowAnonymous]
        [NonAction]
        public async Task<string>  SaveImage(IFormFile imageFile)
        {
            try
            {
               string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName)
                                                .Take(10)
                                                .ToArray()
                                                ).Replace(' ', '-');
            
                imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

                var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                return imageName;
            }
            catch (Exception exeption)
            {
                return exeption.ToString();
            }        
        }

        [NonAction]

        public void DeleteImagem(string imageName)
        {
            var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

    }
}