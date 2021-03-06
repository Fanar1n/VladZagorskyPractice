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
            iServiceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            iServiceCollection.AddScoped<ICreditCardRepository, CreditCardRepository>();
            iServiceCollection.AddScoped<IClientRepository, ClientRepository>();
            iServiceCollection.AddDbContext<ApplicationContext>(c => c.UseSqlServer(iConfiguration.GetConnectionString("DefaultConnection")));
        }
    }
}
