using Bank.DAL.Entities;

namespace Bank.DAL.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCardEntity>> GetAll();
        Task<CreditCardEntity> Get(int id);
        Task<CreditCardEntity> Create(CreditCardEntity item);
        Task<CreditCardEntity> Update(CreditCardEntity item); 
        Task Delete(int id);
    }
}
