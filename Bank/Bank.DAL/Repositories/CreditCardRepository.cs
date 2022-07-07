using Bank.DAL.EF;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly ApplicationContext _db;

        public CreditCardRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public async Task<IEnumerable<CreditCardEntity>> GetAll(CancellationToken token)
        {
            return await _db.CreditCard.AsNoTracking().ToListAsync(token);
        }

        public async Task<CreditCardEntity> Get(int id, CancellationToken token)
        {
            return await _db.CreditCard.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, token);
        }

        public async Task<CreditCardEntity> Create(CreditCardEntity creditCard, CancellationToken token)
        {
            _db.CreditCard.AddAsync(creditCard, token);

            _db.SaveChangesAsync(token);

            return creditCard;
        }

        public async Task<CreditCardEntity> Update(CreditCardEntity creditCard, CancellationToken token)
        {
            _db.CreditCard.Update(creditCard);

            _db.SaveChangesAsync(token);

            return creditCard;
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var creditCard = _db.CreditCard.Find(id);

            _db.CreditCard.Remove(creditCard);

            await _db.SaveChangesAsync(token);
        }
    }
}
