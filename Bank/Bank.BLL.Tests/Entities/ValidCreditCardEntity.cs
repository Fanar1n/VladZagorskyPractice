using Bank.DAL.Entities;

namespace Bank.BLL.Tests.Entity
{
    public static class ValidCreditCardEntity
    {
        public static IEnumerable<CreditCardEntity> CreditCardEntityList = new List<CreditCardEntity>()
        {
            new() { Id = 1, CardNumber = 77777, CVV = 777, OwnerFirstName = "Maksim", OwnerSecondName = "Shamigov" }
        };

        public static CreditCardEntity CreditCardEntity = new()
        { Id = 1, CardNumber = 77777, CVV = 777, OwnerFirstName = "Maksim", OwnerSecondName = "Shamigov" };
    }
}