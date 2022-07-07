using Bank.BLL.Models;

namespace Bank.BLL.Interfaces
{
    public interface ICreditCardServices
    {
        Task<IEnumerable<CreditCard>> GetAll();
        Task<CreditCard> Get(int id);
        Task<CreditCard> Create(CreditCard item);
        Task<CreditCard> Update(CreditCard item);
        Task Delete(int id);
    }
}
