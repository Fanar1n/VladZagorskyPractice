using Bank.DAL.Entities;

namespace Bank.DAL.Interfaces
{
    public interface ICreditCardRepository
    {
        IEnumerable<CreditCardEntity> GetAll();
        CreditCardEntity Get(int id);
        CreditCardEntity Create(CreditCardEntity item);
        CreditCardEntity Update(CreditCardEntity item);
        void Delete(int id);
    }
}
