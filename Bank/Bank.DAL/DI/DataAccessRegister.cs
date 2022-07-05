using Bank.DAL.EF;
using Bank.DAL.Interfaces;
using Bank.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection iServiceCollection, IConfiguration iConfiguration)
        {
            iServiceCollection.AddScoped<ICreditCardRepository, CreditCardRepository>();
            iServiceCollection.AddDbContext<ApplicationContext>(c => c.UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection")));
        }
    }
}
