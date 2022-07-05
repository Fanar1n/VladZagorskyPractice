using Bank.BLL.Infrastructure;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Interfaces;
using Bank.BLL.AMapper;

namespace Bank.BLL.Services
{
    public class CreditCardServices : ICreditCardServices
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly Validation _validation;
        private readonly Mapper _mapper;
        public CreditCardServices(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }
        public IEnumerable<CreditCard> GetAll()
        {
            var result = _creditCardRepository.GetAll();

            var resultToList = new List<CreditCard>();

            foreach (var item in result)
            {
                resultToList.Add(_mapper.ConvertCreditCardEntityToCreditCard(item));
            }

            return resultToList;
        }

        public CreditCard Get(int id)
        {
            var result = _creditCardRepository.Get(id);

            return _mapper.ConvertCreditCardEntityToCreditCard(result);
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

            var creditCardEntity = _mapper.ConvertCreditCardToCreditCardEntity(item);

            var result = _creditCardRepository.Create(creditCardEntity);

            return _mapper.ConvertCreditCardEntityToCreditCard(result);
        }

        public CreditCard Update(CreditCard item)
        {
            if (!_validation.DataValidationId(item.Id)
                 || !_validation.DataValidationCardNumber(item)
                 || !_validation.DataValidationCVV(item)
                 || !_validation.DataValidationOwnerFirstName(item)
                 || !_validation.DataValidationOwnerSecondName(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity =_mapper.ConvertCreditCardToCreditCardEntity(item);

            var result = _creditCardRepository.Update(creditCardEntity);

            return _mapper.ConvertCreditCardEntityToCreditCard(result);
        }

        public void Delete(int id)
        {
            if (!_validation.DataValidationId(id))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            _creditCardRepository.Delete(id);
        }
    }
}
