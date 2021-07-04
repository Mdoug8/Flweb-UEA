using Flweb.Model;
using Flweb.Model.Context;
using Flweb.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Flweb.Repository.Implementation
{
    public class PapelRepository : IPapelRepository
    {
        private MySQLContext _context;

        public PapelRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Papel> FindAll()
        {
            return _context.Papel.ToList();
        }

        public Papel FindById(long id)
        {
            return _context.Papel.SingleOrDefault(p => p.Id.Equals(id));
        }
        public Papel Create(Papel papel)
        {
            try
            {
                _context.Add(papel);
                _context.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
            return papel;
        }
        public Papel Update(Papel papel)
        {
            if (!Exists(papel.Id)) return null;

            var result = _context.Papel.SingleOrDefault(p => p.Id.Equals(papel.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(papel);
                    _context.SaveChanges();

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            return papel;
        }
        public void Delete(long id)
        {
            var result = _context.Papel.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Papel.Remove(result);
                    _context.SaveChanges();

                }
                catch (System.Exception)
                {

                    throw;
                }
            }


        }

        public bool Exists(long id)
        {
            return _context.Papel.Any(p => p.Id.Equals(id));
        }
    }
}
