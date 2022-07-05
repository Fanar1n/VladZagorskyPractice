using Microsoft.EntityFrameworkCore;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Infrastructure
{
    public class Validation
    {
        private readonly ICreditCardRepository<CreditCardEntity> _creditCardRepository;

        public Validation(ICreditCardRepository<CreditCardEntity> creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public bool DataValidationCardNumber(CreditCard creditCard)
        {
            return creditCard.CardNumber.ToString().Length >= 4
                   && creditCard.CardNumber.ToString().Length <= 6;
        }

        public bool DataValidationCVV(CreditCard creditCard)
        {
            return creditCard.CVV.ToString().Length == 3;
        }

        public bool DataValidationOwnerFirstName(CreditCard creditCard)
        {
            return creditCard.OwnerFirstName.Length > 0
                   && creditCard.OwnerFirstName.Length <= 30;
        }

        public bool DataValidationOwnerSecondName(CreditCard creditCard)
        {
            return creditCard.OwnerSecondName.Length > 0
                   && creditCard.OwnerSecondName.Length <= 30;
        }

        public bool DataValidationId(int id)
        {
            return _creditCardRepository.GetAll().FirstOrDefault(p => p.Id == id) is not null;
        }
    }
}
