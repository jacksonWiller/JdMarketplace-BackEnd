using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicationApp.Dtos;
using AplicationApp.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Repositories;


namespace AplicationApp
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProduto _repositoryProduto;
        private readonly ICategoria _repositoryCategoria;
        private readonly IGeneric<Produto> _repositoryGenericProduto;
        private readonly IGeneric<Categoria> _repositoryGenericCategoria;
        private readonly ICategoriaService _serviceCategoria;
        private readonly IMapper _mapper;
        public ProdutoService(IGeneric<Produto> repositoryGeneric,
                              ICategoria repositoryCategoria,
                              IProduto repositoryProduto,
                              IMapper mapper)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryCategoria = repositoryCategoria;
            _repositoryGenericProduto = repositoryGeneric;
            _mapper = mapper;
        }

        public async Task<ProdutoDto> AddProduto(ProdutoDto produtoDto)
        {
            try
            {

                var categorias = await _repositoryCategoria.GetCategoriasAsyncById(produtoDto.Categorias.Select(c => c.Id).ToList());

                var produto = _mapper.Map<Produto>(produtoDto);
                
                produto = Produto.Create(produto.Nome, produto.Descricao, 
                                                    produto.Observacao, produto.Valor,
                                                    produto.QuantidadeEmEstoque,
                                                    produto.ImagemURL,
                                                    produto.ProdutosCategorias);
                
                await _repositoryGenericProduto.Add(produto);
                Console.WriteLine(produto.ProdutosCategorias);

                if (await _repositoryGenericProduto.SaveChangesAsync())
                {
                    var produtoRetorno = await _repositoryProduto.GetProdutoAsyncById(produto.Id);

                    return _mapper.Map<ProdutoDto>(produtoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> UpdateProduto(Guid produtoId, ProdutoDto model)
        {
            try
            {   
                var produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
                if (produto == null) return null;

                model.Id = produto.Id;

                _mapper.Map(model, produto);

                await _repositoryGenericProduto.Update(produto);                

                if (await _repositoryGenericProduto.SaveChangesAsync())
                {
                    var eventoRetorno = await _repositoryProduto.GetProdutoAsyncById(produto.Id);

                    return _mapper.Map<ProdutoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduto(Guid produtoId)
        {
            try
        {
            var produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
            if (produto == null) throw new Exception("Evento para delete não encontrado.");

                await _repositoryGenericProduto.Delete(produto);
            return await _repositoryGenericProduto.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        }
        public async Task<ProdutoDto[]> GetAllProdutosAsync()
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsync();
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ProdutoDto[]> GetAllProdutosAsyncByNome(string nome)
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsyncByNome(nome);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto[]>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDto> GetProdutoAsyncById(Guid produtosId)
        {
            try
            {
                var produto = await _repositoryProduto.GetProdutoAsyncById(produtosId);
                if (produto == null) return null;

                var resultado = _mapper.Map<ProdutoDto>(produto);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}