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
        private readonly IMapper _mapper;
        public CreditCardService(IGenericRepository<CreditCardEntity> genericRepository, IMapper mapper,ICreditCardRepository creditCardRepository) : base(genericRepository, mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }

        public override async Task<CreditCard> Update(CreditCard item, CancellationToken token)
        {
            var tModel = await _creditCardRepository.Get(item.Id, token);

            if (tModel == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var tEntity = _mapper.Map<CreditCardEntity>(item);
            var result = await _creditCardRepository.Update(tEntity, token);

            return _mapper.Map<CreditCard>(result);
        }
    }
}