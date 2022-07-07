﻿using AutoMapper;
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
        public async Task<IEnumerable<CreditCard>> GetAll(CancellationToken token)
        {
            var result = await _creditCardRepository.GetAll(token);

            var resultToList = new List<CreditCard>();

            foreach (var item in result)
            {
                resultToList.Add(_mapper.Map<CreditCard>(item));
            }

            return resultToList;
        }

        public async Task<CreditCard> Get(int id, CancellationToken token)
        {
            var result = await _creditCardRepository.Get(id, token);

            return _mapper.Map<CreditCard>(result);
        }

        public async Task<CreditCard> Create(CreditCard item, CancellationToken token)
        {
            if (!_validation.IsCardNumberValid(item)
                || !_validation.IsCvvValid(item)
                || !_validation.IsOwnerFirstNameValid(item)
                || !_validation.IsOwnerSecondNameValid(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = _mapper.Map<CreditCardEntity>(item);

            var result = await _creditCardRepository.Create(creditCardEntity, token);

            return _mapper.Map<CreditCard>(result);
        }

        public async Task<CreditCard> Update(CreditCard item, CancellationToken token)
        {
            if (!_validation.DataValidationId(item.Id, token)
                 || !_validation.IsCardNumberValid(item)
                 || !_validation.IsCvvValid(item)
                 || !_validation.IsOwnerFirstNameValid(item)
                 || !_validation.IsOwnerSecondNameValid(item))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var creditCardEntity = _mapper.Map<CreditCardEntity>(item);

            var result = await _creditCardRepository.Update(creditCardEntity, token);

            return _mapper.Map<CreditCard>(result);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            if (!_validation.DataValidationId(id, token))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _creditCardRepository.Delete(id, token);
        }
    }
}
