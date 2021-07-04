using Microsoft.EntityFrameworkCore;

namespace Flweb.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<File> Arquivos { get; set; }

        public DbSet<Atualizacao> Atualizacoes { get; set;}

        public DbSet<Papel> Papel { get; set; }

        


    }
}
