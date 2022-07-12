using Bank.DAL.EF;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.DAL.Repositories
{
    public class ClientRepository : GenericRepository<ClientEntity>, IClientRepository
    {
        public ClientRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
