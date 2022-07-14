using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class CreditCardService : GenericService<CreditCard, CreditCardEntity>, ICreditCardServices
    {
        public CreditCardService(IGenericRepository<CreditCardEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }

        public override async Task<CreditCard> Create(CreditCard creditCard, CancellationToken token)
        {
            var tEntity = _mapper.Map<CreditCardEntity>(creditCard);
            var result = await _genericRepository.Create(tEntity, token);

            var creditCardWithClient = _genericRepository.Get(result.Id, token);

            return _mapper.Map<CreditCard>(creditCardWithClient);
        }
    }
}