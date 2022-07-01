using Microsoft.EntityFrameworkCore;

namespace Bank.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CreditCard> CreditCard => Set<CreditCard>();

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { Database.EnsureCreated(); }
    }
}
