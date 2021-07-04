using Flweb.Model;
using System.Collections.Generic;

namespace Flweb.Repository.Interface
{
    public interface IAtualizacaoRepository
    {
        List<Atualizacao> FindAll();
        Atualizacao FindByID(long id);
        Atualizacao Create(Atualizacao atualizacao);
        Atualizacao Update(Atualizacao atualizacao);
        void Delete(long id);
        bool Exists(long id);
    }
}
