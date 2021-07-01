using Flweb.Model;
using Flweb.Model.Context;
using Flweb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Repository.Implementation
{
    public class FileRepository : IFileRepository
    {
        private MySQLContext _context;

        public FileRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Arquivo> FindAll()
        {
            return _context.Arquivos.ToList();
        }

        public Arquivo FindByID(long id)
        {
            return _context.Arquivos.SingleOrDefault(p => p.IdArquivo.Equals(id));
        }

        public Arquivo Create(Arquivo arquivo)
        {
            try
            {
                _context.Add(arquivo);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
            return arquivo;
        }

        public Arquivo Update(Arquivo arquivo)
        {
            if (!Exists(arquivo.IdArquivo)) return null;

            var result = _context.Arquivos.SingleOrDefault(p => p.IdArquivo.Equals(arquivo.IdArquivo));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(arquivo);
                    _context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return arquivo;

        }
        public void delete(long id)
        {
            var result = _context.Arquivos.SingleOrDefault(p => p.IdArquivo.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Arquivos.Remove(result);
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
            return _context.Arquivos.Any(p => p.IdArquivo.Equals(id));
        }
    }
}
