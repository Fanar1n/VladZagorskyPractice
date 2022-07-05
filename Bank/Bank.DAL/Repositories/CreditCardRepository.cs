using Bank.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.DAL.Repositories
{
    public class CreditCardRepository : ICreditCardRepository<CreditCardEntity>
    {
        private readonly ApplicationContext _db;

        public CreditCardRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
        }

        public IEnumerable<CreditCardEntity> GetAll()
        {
            return _db.CreditCard.ToList();
        }

        public CreditCardEntity Get(int id)
        {
            return _db.CreditCard.Find(id);
        }

        public CreditCardEntity Create(CreditCardEntity creditCard)
        {
            _db.CreditCard.Add(creditCard);

            return creditCard;
        }

        public CreditCardEntity Update(CreditCardEntity creditCard)
        {
            _db.CreditCard.Update(creditCard);
            
            return creditCard;
        }

        public void Delete(int id)
        {
           var creditCard = _db.CreditCard.Find(id);

           _db.CreditCard.Remove(creditCard);
        }
    }
}
