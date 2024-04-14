using AplicationApp.Dtos;
using Domain.Entity;
using Infrastructure.Repository.Repositories;
using JdMarketplace.App.Commands;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JdMarketplace.App.Queries.Catalogo.ObterProdutoPorId
{
    public class ObterProdutoPorIdHandler : IObterProdutoPorIdHandler
    {
        public readonly DataContext _dataContext;

        public ObterProdutoPorIdHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ObterProdutoPorIdResponse> Handle(ObterProdutoPorIdRequest query)
        {
            try
            {
                var produto = await _dataContext.Produtos.FirstOrDefaultAsync(p => p.Id == query.Id);

                return new ObterProdutoPorIdResponse
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Valor = produto.Valor,
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
