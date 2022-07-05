using Microsoft.EntityFrameworkCore;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Infrastructure
{
    public class Validation
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public Validation(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public bool IsCardNumberValid(CreditCard creditCard)
        {
            return creditCard.CardNumber.ToString().Length >= 4
                   && creditCard.CardNumber.ToString().Length <= 6;
        }

        public bool IsCvvValid(CreditCard creditCard)
        {
            return creditCard.CVV.ToString().Length == 3;
        }

        public bool IsOwnerFirstNameValid(CreditCard creditCard)
        {
            return creditCard.OwnerFirstName.Length > 0
                   && creditCard.OwnerFirstName.Length <= 30;
        }

        public bool IsOwnerSecondNameValid(CreditCard creditCard)
        {
            return creditCard.OwnerSecondName.Length > 0
                   && creditCard.OwnerSecondName.Length <= 30;
        }

        public bool DataValidationId(int id)
        {
            var creditCard = _creditCardRepository.Get(id);

            if (creditCard == null)
            {
                return false;
            }

            return true;
        }
    }
}
