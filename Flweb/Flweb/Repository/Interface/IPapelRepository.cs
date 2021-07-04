using Flweb.Model;
using System.Collections.Generic;

namespace Flweb.Repository.Interface
{
    public interface IPapelRepository
    {
        List<Papel> FindAll();
        Papel FindById(long id);
        Papel Create(Papel papel);
        Papel Update(Papel papel);
        void Delete(long id);
        bool Exists(long id);
    }
}
