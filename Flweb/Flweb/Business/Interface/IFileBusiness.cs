using Flweb.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flweb.Business.Interface
{
    public interface IFileBusiness
    {
        //metodo para le o arquivo em disco
        //ele vai le o arquivo e vai transformar num bytearray antes de devolver ele
        public byte[] GetFile(string filename);

        //metodo para salvar o arquivo em disco
        // esse metodo sera assincrono, ou seja ele vai iniciar a tarefa e o controller tem que esperar a resposta pra devolver
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);

        //metodo para salvar varios arquivos em disco
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}
