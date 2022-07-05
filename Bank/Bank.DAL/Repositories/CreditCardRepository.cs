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

        public IEnumerable<CreditCardEntity> GetAll()
        {
            return _db.CreditCard.AsNoTracking().ToList();
        }

        public CreditCardEntity Get(int id)
        {
            return _db.CreditCard.AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public CreditCardEntity Create(CreditCardEntity creditCard)
        {
            _db.CreditCard.Add(creditCard);

            _db.SaveChanges();

            return creditCard;
        }

        public CreditCardEntity Update(CreditCardEntity creditCard)
        {
            _db.CreditCard.Update(creditCard);

            _db.SaveChanges();

            return creditCard;
        }

        public void Delete(int id)
        {
            var creditCard = _db.CreditCard.Find(id);

            _db.CreditCard.Remove(creditCard);

            _db.SaveChanges();
        }
    }
}
