using Bank.DAL.Entities;

namespace Bank.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<ClientEntity>> GetAll(CancellationToken token);
        Task<ClientEntity> Get(int id, CancellationToken token);
        Task<ClientEntity> Create(ClientEntity item, CancellationToken token);
        Task<ClientEntity> Update(ClientEntity item, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}
