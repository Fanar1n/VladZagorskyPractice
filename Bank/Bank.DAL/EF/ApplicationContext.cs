using Bank.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CreditCardEntity> CreditCard => Set<CreditCardEntity>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { Database.EnsureCreated(); }

    }
}
