using Bank.DAL.Entities;

namespace Bank.BLL.Tests.Entity
{
    public static class ValidCreditCardEntity
    {
        public static IEnumerable<CreditCardEntity> CreditCardEntityList = new List<CreditCardEntity>()
        {
            new() { Id = 1,
                CardNumber = 77777,
                CVV = 777, ClientId = 1,
                Client = new()
                {
                    FirstName = "Vlad",
                    SecondName = "Zagorsky",
                    PhoneNumber = "+375293710904"
                }}
        };

        public static CreditCardEntity CreditCardEntity = new()
        {
            Id = 1,
            CardNumber = 77777,
            CVV = 777,
            ClientId = 1,
            Client = new()
            {
                FirstName = "Vlad",
                SecondName = "Zagorsky",
                PhoneNumber = "+375293710904"
            }
        };
    }
}