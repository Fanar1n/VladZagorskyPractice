using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CreditCard> CreditCards => Set<CreditCard>();
        public ApplicationContext() => Database.EnsureCreated();    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DankDB;Trusted_Connection=True;");
        }
    }
}
