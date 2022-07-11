using Bank.BLL.Models;

namespace Bank.BLL.Tests.Models
{
    public static class ValidCreditCard
    {
        public static IEnumerable<CreditCard> CreditCardList = new List<CreditCard>()
        {
            new() { Id = 1, CardNumber = 77777, CVV = 777, OwnerFirstName = "Maksim", OwnerSecondName = "Shamigov" }
        };

        public static CreditCard CreditCard = new()
        {Id = 1, CardNumber = 77777, CVV = 777, OwnerFirstName = "Maksim", OwnerSecondName = "Shamigov" };
    }
}
