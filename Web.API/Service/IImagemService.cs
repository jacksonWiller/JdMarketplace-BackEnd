using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace JdMarketplace.Api.Service
{
    public interface IImagemService
    {
        Task<string> SalvarImagem(IFormFile imageFile);
        void DeletarImagem(string imageName);
    }
}
