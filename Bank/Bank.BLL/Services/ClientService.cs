using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;

namespace Bank.BLL.Services
{
    public class ClientService : GenericService<Client, ClientEntity>, IClientService
    {
        public ClientService(DAL.Interfaces.IGenericRepository<ClientEntity> genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
    }
}
