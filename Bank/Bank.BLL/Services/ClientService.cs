using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class ClientService : GenericService<Client, ClientEntity>, IClientService
    {
        public ClientService(IClientRepository clientRepository, IMapper mapper) : base(clientRepository, mapper)
        {
        }
    }
}
