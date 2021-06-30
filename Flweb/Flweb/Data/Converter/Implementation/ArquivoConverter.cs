using Flweb.Data.Converter.Contract;
using Flweb.Data.VO;
using Flweb.Model;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Data.Converter.Implementation
{
    public class ArquivoConverter : IParser<ArquivoVO, Arquivo>, IParser<Arquivo, ArquivoVO>
    {
        public Arquivo Parse(ArquivoVO origin)
        {
            if (origin == null) return null;

            return new Arquivo
            {
                Name = origin.Name
            };
        }
        public ArquivoVO Parse(Arquivo origin)
        {
            if (origin == null) return null;

            return new ArquivoVO
            {
                Name = origin.Name
            };
        }

        public List<Arquivo> Parse(List<ArquivoVO> origin)
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

        public List<ArquivoVO> Parse(List<Arquivo> origin)
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
