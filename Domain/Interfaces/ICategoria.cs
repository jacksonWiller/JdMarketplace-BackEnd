using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface ICategoria
    {
        //PRODUTOS
        Task<Categoria[]> GetAllCategoriasAsync();
        Task<Categoria[]> GetAllCategoriasAsyncByNome( string nome);
        Task<Categoria> GetCategoriaAsyncById(Guid CategoriaId);
        Task<List<Categoria>> GetCategoriasAsyncById(List<Guid> IdsCategoria);
    }
}