using Bank.BLL.Interfaces;
using Bank.BLL.Services;
using Bank.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection iServiceCollection, IConfiguration iConfiguration)
        {
            iServiceCollection.AddScoped<ICreditCardServices, CreditCardService>();
            iServiceCollection.AddDataAccess(iConfiguration);
        }
    }
}
