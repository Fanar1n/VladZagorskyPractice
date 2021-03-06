using Bank.BLL.Models;

namespace Bank.API.Tests.Models
{
    public static class ValidCreditCard
    {
        public static IEnumerable<CreditCard> InitListCreditCards = new List<CreditCard>
        {
            new() { Id = 1, CardNumber = 4444, CVV = 444, ClientId = 1}
        };

        public static CreditCard CreditCardModel = new() { CardNumber = 4444, CVV = 444, ClientId = 1 };
    }
}