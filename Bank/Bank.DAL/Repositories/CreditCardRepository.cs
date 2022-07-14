using Bank.DAL.EF;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories
{
    public class CreditCardRepository : GenericRepository<CreditCardEntity>, ICreditCardRepository
    {
        public CreditCardRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public override async Task<CreditCardEntity> Get(int id, CancellationToken token)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
