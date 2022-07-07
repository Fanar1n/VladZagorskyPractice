using Bank.DAL.Entities;

namespace Bank.DAL.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCardEntity>> GetAll(CancellationToken token);
        Task<CreditCardEntity> Get(int id, CancellationToken token);
        Task<CreditCardEntity> Create(CreditCardEntity item, CancellationToken token);
        Task<CreditCardEntity> Update(CreditCardEntity item, CancellationToken token); 
        Task Delete(int id, CancellationToken token);
    }
}
