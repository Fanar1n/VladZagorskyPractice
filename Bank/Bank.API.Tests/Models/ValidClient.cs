using Bank.BLL.Models;

namespace Bank.API.Tests.Models
{
    public class ValidClient
    {
        public static IEnumerable<Client> InitListClient = new List<Client>
        {
            new() { Id = 1, FirstName = "Vlad", SecondName = "Zagorsky" , PhoneNumber = "+375293710904" }
        };

        public static Client ClientModel = new() { Id = 1, FirstName = "Vlad", SecondName = "Zagorsky", PhoneNumber = "+375293710904" };
    }
}