using Bank.BLL.Models;
using Bank.Models;

namespace Bank.Mappers
{
    public static class Mapper
    {
        public static CreditCardViewModel ConvertCreditCardToCreditCardViewModel(CreditCard item)
        {
            var result = new CreditCardViewModel
            {
                Id = item.Id,
                CardNumber = item.CardNumber,
                CVV = item.CVV,
                OwnerFirstName = item.OwnerFirstName,
                OwnerSecondName = item.OwnerSecondName
            };

            return result;
        }

        public static CreditCard ConvertCreditCardViewModelToCreditCard(CreditCardViewModel item)
        {
            var result = new CreditCard
            {
                Id = item.Id,
                CardNumber = item.CardNumber,
                CVV = item.CVV,
                OwnerFirstName = item.OwnerFirstName,
                OwnerSecondName = item.OwnerSecondName
            };

            return result;
        }
    }
}
