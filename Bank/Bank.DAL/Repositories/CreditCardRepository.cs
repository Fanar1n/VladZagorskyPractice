using Bank.DAL.EF;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.DAL.Repositories
{
    public class CreditCardRepository : GenericRepository<CreditCardEntity> ,ICreditCardRepository
    {
        public CreditCardRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
