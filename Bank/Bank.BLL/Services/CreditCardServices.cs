using Bank.BLL.Infrastructure;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class CreditCardServices : ICreditCardServices<CreditCard>
    {
        private readonly ICreditCardRepository<CreditCardEntity> _creditCardRepository;
        private readonly Validation _validation;
        public CreditCardServices(ICreditCardRepository<CreditCardEntity> creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        public IEnumerable<CreditCard> GetAll()
        {
            var result = _creditCardRepository.GetAll();

            var resultToList = new List<CreditCard>();

            foreach (var item in result)
            {
                resultToList.Add(ConvertCreditCardEntityToCreditCard(item));
            }

            return resultToList;
        }

        public CreditCard Get(int id)
        {
           var result = _creditCardRepository.Get(id);

           return ConvertCreditCardEntityToCreditCard(result);
        }

        public CreditCard Create(CreditCard item)
        {
            if (!_validation.DataValidationCardNumber(item)
                || !_validation.DataValidationCVV(item)
                || !_validation.DataValidationOwnerFirstName(item)
                || !_validation.DataValidationOwnerSecondName(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = ConvertCreditCardToCreditCardEntity(item);

            var result = _creditCardRepository.Create(creditCardEntity);

            return ConvertCreditCardEntityToCreditCard(result);
        }

        public CreditCard Update(CreditCard item)
        {
            if ( !_validation.DataValidationId(item.Id)
                 || !_validation.DataValidationCardNumber(item)
                 || !_validation.DataValidationCVV(item)
                 || !_validation.DataValidationOwnerFirstName(item)
                 || !_validation.DataValidationOwnerSecondName(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = ConvertCreditCardToCreditCardEntity(item);

            var result = _creditCardRepository.Update(creditCardEntity);

            return ConvertCreditCardEntityToCreditCard(result);
        }

        public void Delete(int id)
        {
            if (!_validation.DataValidationId(id))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            _creditCardRepository.Delete(id);
        }

        private CreditCardEntity ConvertCreditCardToCreditCardEntity(CreditCard item)
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

        private CreditCard ConvertCreditCardEntityToCreditCard(CreditCardEntity item)
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
