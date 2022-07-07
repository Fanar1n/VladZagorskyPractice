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

        public async Task<IEnumerable<CreditCardEntity>> GetAll()
        {
            return await _db.CreditCard.AsNoTracking().ToListAsync();
        }

        public async Task<CreditCardEntity> Get(int id)
        {
            return await _db.CreditCard.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<CreditCardEntity> Create(CreditCardEntity creditCard)
        {
            _db.CreditCard.AddAsync(creditCard);

            _db.SaveChangesAsync();

            return creditCard;
        }

        public async Task<CreditCardEntity> Update(CreditCardEntity creditCard)
        {
            _db.CreditCard.Update(creditCard);

            _db.SaveChangesAsync();

            return creditCard;
        }

        public async Task Delete(int id)
        {
            var creditCard = _db.CreditCard.Find(id);

            _db.CreditCard.Remove(creditCard);

            await _db.SaveChangesAsync();
        }
    }
}
