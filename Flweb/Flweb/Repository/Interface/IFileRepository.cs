using Flweb.Model;
using System.Collections.Generic;

namespace Flweb.Repository.Interface
{
    public interface IFileRepository
    {
        Arquivo Create(Arquivo arquivo);
        Arquivo FindByID(long id);
        List<Arquivo> FindAll();
        Arquivo Update(Arquivo arquivo);
        void delete(long id);
        bool Exists(long id);
    }
}
