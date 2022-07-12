using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class CreditCardService : GenericService<CreditCard, CreditCardEntity>, ICreditCardServices
    {
        public CreditCardService(IGenericRepository<CreditCardEntity> genericRepository, IMapper mapper,ICreditCardRepository creditCardRepository) : base(genericRepository, mapper)
        {
        }
    }
}