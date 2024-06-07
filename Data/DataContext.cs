using gsnet.Models;
using Microsoft.EntityFrameworkCore;
namespace gsnet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Coral> Corais { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
