using Flweb.Model;
using System.Collections.Generic;

namespace Flweb.Repository.Interface
{
    public interface IAtualizacaoRepository
    {
        Atualizacao Create(Atualizacao atualizacao);
        Atualizacao FindByID(long id);
        List<Atualizacao> FindAll();
        Atualizacao Update(Atualizacao atualizacao);
        void Delete(long id);
        bool Exists(long id);


    }
}
