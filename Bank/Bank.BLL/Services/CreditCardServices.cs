using AutoMapper;
using Bank.BLL.Infrastructure;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class CreditCardServices : ICreditCardServices
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly Validation _validation;
        private readonly IMapper _mapper;

        public CreditCardServices(
            ICreditCardRepository creditCardRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _creditCardRepository = creditCardRepository;
            _validation = new Validation(creditCardRepository);
        }
        public IEnumerable<CreditCard> GetAll()
        {
            var result = _creditCardRepository.GetAll();

            var resultToList = new List<CreditCard>();

            foreach (var item in result)
            {
                resultToList.Add(_mapper.Map<CreditCard>(item));
            }

            return resultToList;
        }

        public CreditCard Get(int id)
        {
            var result = _creditCardRepository.Get(id);

            return _mapper.Map<CreditCard>(result);
        }

        public CreditCard Create(CreditCard item)
        {
            if (!_validation.IsCardNumberValid(item)
                || !_validation.IsCvvValid(item)
                || !_validation.IsOwnerFirstNameValid(item)
                || !_validation.IsOwnerSecondNameValid(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = _mapper.Map<CreditCardEntity>(item);

            var result = _creditCardRepository.Create(creditCardEntity);

            return _mapper.Map<CreditCard>(result);
        }

        public CreditCard Update(CreditCard item)
        {
            if (!_validation.DataValidationId(item.Id)
                 || !_validation.IsCardNumberValid(item)
                 || !_validation.IsCvvValid(item)
                 || !_validation.IsOwnerFirstNameValid(item)
                 || !_validation.IsOwnerSecondNameValid(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = _mapper.Map<CreditCardEntity>(item);

            var result = _creditCardRepository.Update(creditCardEntity);

            return _mapper.Map<CreditCard>(result);
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
