using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using System;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace JdMarketplace.Api.Service
{
    public class ImagemService : IImagemService
    {
        private readonly IWebHostEnvironment _hostEnviroment;

        public ImagemService(IWebHostEnvironment IWebHostEnviroment)
        {
            _hostEnviroment = IWebHostEnviroment;
        }

        public async Task<string> SalvarImagem(IFormFile imageFile)
        {
            try
            {
                var codigoImagem = Guid.NewGuid();
                // Obtendo a extensão original do arquivo
                var extensaoArquivo = Path.GetExtension(imageFile.FileName);

                // Construindo o nome da imagem com o código GUID e a extensão original
                var nomeImagem = $"{codigoImagem}{extensaoArquivo}";

                // Caminho completo onde a imagem será salva
                var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", nomeImagem);

                // Salvando a imagem no caminho especificado
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Retornando o caminho da imagem
                var imageUrl = $"/Resources/Images/{codigoImagem}{Path.GetExtension(imageFile.FileName)}";

                return imageUrl;
            }
            catch (Exception exception)
            {
                // Retornando a exceção como string caso ocorra algum erro
                return exception.ToString();
            }
        }

        public void DeletarImagem(string imageName)
        {
            var imagePath = Path.Combine(_hostEnviroment.ContentRootPath, @"Resources/Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
