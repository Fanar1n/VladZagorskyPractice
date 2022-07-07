using Bank.BLL.Models;

namespace Bank.BLL.Interfaces
{
    public interface ICreditCardServices
    {
        Task<IEnumerable<CreditCard>> GetAll(CancellationToken token);
        Task<CreditCard> Get(int id, CancellationToken token);
        Task<CreditCard> Create(CreditCard item, CancellationToken token);
        Task<CreditCard> Update(CreditCard item, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}
