using Bank.BLL.Models;

namespace Bank.BLL.Tests.Models
{
    public class ValidClient
    {
        public static IEnumerable<Client> InitListClient = new List<Client>
        {
            new() { Id = 1, FirstName = "Sergey", SecondName = "Zyl" , PhoneNumber = "+375295553535" }
        };

        public static Client Client = new() { Id = 1, FirstName = "Sergey", SecondName = "Zyl", PhoneNumber = "+375295553535" };
    }
}
