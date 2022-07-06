using Bank.BLL.Models;

namespace Bank.BLL.Interfaces
{
    public interface ICreditCardServices
    {
        IEnumerable<CreditCard> GetAll();
        CreditCard Get(int id);
        CreditCard Create(CreditCard item);
        CreditCard Update(CreditCard item);
        void Delete(int id);
    }
}
