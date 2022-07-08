using System.Dynamic;
using Bank.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CreditCardEntity> CreditCard { get; set; }
        public DbSet<ClientEntity> Client { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { Database.Migrate(); }

    }
}
