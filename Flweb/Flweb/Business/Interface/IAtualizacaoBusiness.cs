using Flweb.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flweb.Business.Interface
{
    public interface IAtualizacaoBusiness
    {
        List<AtualizacaoVO> FindAll();

        AtualizacaoVO FindById(long id);
        AtualizacaoVO Create(AtualizacaoVO atualizacao);
        AtualizacaoVO Update(AtualizacaoVO atualizacao);
        void Delete(long id);
    }
}
