using Bank.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Services
{
    public class Validation
    {
        private readonly ApplicationContext _db;

        public Validation (ApplicationContext db)
        {
            _db = db;
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
            var creditCard = _db.CreditCard.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (creditCard == null)
            {
                return true;
            }

            return false;
        }
    }
}
