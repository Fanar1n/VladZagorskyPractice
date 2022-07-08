using Bank.BLL.Models;

namespace Bank.BLL.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAll(CancellationToken token);
        Task<Client> Get(int id, CancellationToken token);
        Task<Client> Create(Client item, CancellationToken token);
        Task<Client> Update(Client item, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}
