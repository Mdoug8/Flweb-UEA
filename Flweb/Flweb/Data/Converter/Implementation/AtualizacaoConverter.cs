using Flweb.Data.Converter.Contract;
using Flweb.Data.VO;
using Flweb.Model;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Data.Converter.Implementation
{
    public class AtualizacaoConverter : IParser<AtualizacaoVO, Atualizacao>, IParser<Atualizacao, AtualizacaoVO>
    {
        public Atualizacao Parse(AtualizacaoVO origin)
        {
            if (origin == null) return null;

            return new Atualizacao
            {
                IdAtualizacao = origin.IdAtualizacao,
                Versao = origin.Versao,
                Name = origin.Name,
                Modelo = origin.Modelo
                //StatusAtualizacao = origin.StatusAtualizacao
            };
        }

        public AtualizacaoVO Parse(Atualizacao origin)
        {
            if (origin == null) return null;

            return new AtualizacaoVO
            {
                IdAtualizacao = origin.IdAtualizacao,
                Versao = origin.Versao,
                Name = origin.Name,
                Modelo = origin.Modelo
                //StatusAtualizacao = origin.StatusAtualizacao
            };

        }

        public List<Atualizacao> Parse(List<AtualizacaoVO> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }

       

        public List<AtualizacaoVO> Parse(List<Atualizacao> origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return origin.Select(item => Parse(item)).ToList();
            }
        }
    }
}
