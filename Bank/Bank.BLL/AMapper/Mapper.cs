using Bank.BLL.Models;
using Bank.DAL.Entities;

namespace Bank.BLL.AMapper
{
    public class Mapper
    {
        public CreditCardEntity ConvertCreditCardToCreditCardEntity(CreditCard item)
        {
            var result = new CreditCardEntity
            {
                CardNumber = item.CardNumber,
                CVV = item.CVV,
                OwnerFirstName = item.OwnerFirstName,
                OwnerSecondName = item.OwnerSecondName
            };

            return result;
        }

        public CreditCard ConvertCreditCardEntityToCreditCard(CreditCardEntity item)
        {
            var result = new CreditCard
            {
                CardNumber = item.CardNumber,
                CVV = item.CVV,
                OwnerFirstName = item.OwnerFirstName,
                OwnerSecondName = item.OwnerSecondName
            };

            return result;
        }
    }
}
