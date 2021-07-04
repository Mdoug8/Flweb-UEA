using Flweb.Model;
using System.Collections.Generic;

namespace Flweb.Repository.Interface
{
    public interface IFileRepository
    {
        File Create(File arquivo);
        File FindByID(long id);
        List<File> FindAll();
        File Update(File arquivo);
        void delete(long id);
        bool Exists(long id);
    }
}
