using Flweb.Model;
using Flweb.Model.Context;
using Flweb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Repository.Implementation
{
    public class AtualizacaoRepository : IAtualizacaoRepository
    {
        private MySQLContext _context;

        public AtualizacaoRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Atualizacao> FindAll()
        {
            return _context.Atualizacoes.ToList();
        }

        public Atualizacao FindByID(long id)
        {
            return _context.Atualizacoes.SingleOrDefault(p => p.IdAtualizacao.Equals(id));
        }

        public Atualizacao Create(Atualizacao atualizacao)
        {
            try
            {
                _context.Add(atualizacao);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return atualizacao;
        }

        public Atualizacao Update(Atualizacao atualizacao)
        {
            if (!Exists(atualizacao.IdAtualizacao)) return null;

            var result = _context.Atualizacoes.SingleOrDefault(p => p.IdAtualizacao.Equals(atualizacao.IdAtualizacao));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(atualizacao);
                    _context.SaveChanges();
                    return result;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _context.Atualizacoes.SingleOrDefault(p => p.IdAtualizacao.Equals(id));
            if(result != null)
            {
                try
                {
                    _context.Atualizacoes.Remove(result);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Atualizacoes.Any(p => p.IdAtualizacao.Equals(id));
        }

        
    }
}
