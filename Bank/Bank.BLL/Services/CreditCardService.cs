using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class CreditCardService : GenericService<CreditCard, CreditCardEntity>, ICreditCardServices
    {
        private readonly ICreditCardRepository _creditCardRepository;
        public CreditCardService(IMapper mapper, ICreditCardRepository creditCardRepository) : base(creditCardRepository, mapper)
        {
            _creditCardRepository = creditCardRepository;
        }

        public override async Task<CreditCard> Create(CreditCard creditCard, CancellationToken token)
        {
            var entity = _mapper.Map<CreditCardEntity>(creditCard);
            var result = await _creditCardRepository.Create(entity, token);

            var creditCardWithClient = await _creditCardRepository.Get(result.Id, token);

            return _mapper.Map<CreditCard>(creditCardWithClient);
        }

        public override async Task<CreditCard> Update(CreditCard item, CancellationToken token)
        {
            var entity = _mapper.Map<CreditCardEntity>(item);
            var result = await _creditCardRepository.Update(entity, token);

            var creditCardWithClient = await _creditCardRepository.Get(result.Id, token);

            return _mapper.Map<CreditCard>(creditCardWithClient);
        }
    }
}