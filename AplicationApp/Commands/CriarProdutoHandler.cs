using AplicationApp.Dtos;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Repository.Repositories;
using ProAgil.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Commands
{
    public class CriarProdutoHandler : ICriarProdutoHandler
    {
        public readonly DataContext _dataContext;

        public CriarProdutoHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CriarProdutoResponse Handle(CriarProdutoRequest command)
        {
            try
            {
                var produto = Produto.Create(command.Nome, command.Descricao,
                                                    command.Observacao, command.Valor,
                                                    command.QuantidadeEmEstoque);

                _dataContext.Add(produto);
                var save = _dataContext.SaveChangesAsync();

  
                    return new CriarProdutoResponse
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        
                    };
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
