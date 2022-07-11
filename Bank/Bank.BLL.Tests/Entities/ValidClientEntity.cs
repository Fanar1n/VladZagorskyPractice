using Bank.DAL.Entities;

namespace Bank.BLL.Tests.Entities
{
    public class ValidClientEntity
    {
        public static IEnumerable<ClientEntity> InitListClientEntity = new List<ClientEntity>
        {
            new() { Id = 1, FirstName = "Sergey", SecondName = "Zyl" , PhoneNumber = "+375295553535" }
        };

        public static ClientEntity ClientEntity =
            new() { Id = 1, FirstName = "Sergey", SecondName = "Zyl", PhoneNumber = "+375295553535" };
    }
}
