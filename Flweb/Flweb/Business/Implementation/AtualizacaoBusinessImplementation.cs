using Flweb.Business.Interface;
using Flweb.Data.Converter.Implementation;
using Flweb.Data.VO;
using Flweb.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Flweb.Business.Implementation
{
    public class AtualizacaoBusinessImplementation : IAtualizacaoBusiness
    {
        private readonly IAtualizacaoRepository _repository;
        private readonly AtualizacaoConverter _converter;

        public AtualizacaoBusinessImplementation(IAtualizacaoRepository repository)
        {
            _repository = repository;
            _converter = new AtualizacaoConverter();
        }

        public AtualizacaoVO Create(AtualizacaoVO atualizacao)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<AtualizacaoVO> FindAll()
        {
            throw new NotImplementedException();
        }

        public AtualizacaoVO FindById(long id)
        {
            throw new NotImplementedException();
        }

        public AtualizacaoVO Update(AtualizacaoVO atualizacao)
        {
            throw new NotImplementedException();
        }
    }
}
