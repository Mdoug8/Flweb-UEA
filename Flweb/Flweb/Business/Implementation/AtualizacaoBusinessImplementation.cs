using Flweb.Business.Interface;
using Flweb.Data.Converter.Implementation;
using Flweb.Data.VO;
using Flweb.Repository.Interface;
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

        public List<AtualizacaoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public AtualizacaoVO FindById(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }
        public AtualizacaoVO Create(AtualizacaoVO atualizacao)
        {
            var atualizacaoEntity = _converter.Parse(atualizacao);

            atualizacaoEntity = _repository.Create(atualizacaoEntity);

            return _converter.Parse(atualizacaoEntity); 
        }
        public AtualizacaoVO Update(AtualizacaoVO atualizacao)
        {
            var atualizacaoEntity = _converter.Parse(atualizacao);

            atualizacaoEntity = _repository.Update(atualizacaoEntity);

            return _converter.Parse(atualizacaoEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
