using Flweb.Business.Interface;
using Flweb.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Flweb.Business.Implementation
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            //Directory.GetCurrentDirectory() pega o diretorio corrente
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;
            return File.ReadAllBytes(filePath);
        }

        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            //as informações que ele vai retornar como o nome do documento, tipo e url
            // essas informacoes são retornadas atraves do fileDetail
            FileDetailVO fileDetail = new FileDetailVO();

            //descobre a extensão do arquivo
            var fileType = Path.GetExtension(file.FileName);
            // ele monta a base url se baseando nas configurações do host
            var baseUrl = _context.HttpContext.Request.Host;

            //se estiver em algumas dessas extensões vai ser aceito o upload
            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" ||
                fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                //armazena em docName o nome do arquivo
                var docName = Path.GetFileName(file.FileName);
                // verifica se o arquivo e nulo ou se ele e vazio, assim ele pode proceder com a gravacao   
                if (file != null && file.Length > 0)
                {
                    // monta o destino onde vai ser salvo
                    // o _basePath é onde está a pasta e concactena isso com o nome do documento 
                    var destination = Path.Combine(_basePath, "", docName);
                    // o nome do arquivo e setado no fileDetail, para que ela possa ser retornada
                    fileDetail.DocumentName = docName;
                    // o tipo do arquivo e setado no fileDetail, para que ela possa ser retornada
                    fileDetail.DocType = fileType;

                    //link para que posteriormente possa ser possivel fazer o download
                    fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                    //gravacao no disco, 
                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }

            }
            // retorna as informaçoes do arquivo como nome, tipo e a url
            return fileDetail;
        }

        public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();

            foreach (var file in files)
            {
                //ele vai pegar todos os files, e pra cada file ele vai salvar ele 
                // pra cada file ele processa e gera o VO, seta os seus valores e devolve de volta adicionando na lista
                list.Add(await SaveFileToDisk(file));
            }
            return list;
        }

    }
}
