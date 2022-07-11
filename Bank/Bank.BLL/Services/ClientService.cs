using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;

namespace Bank.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(
            IClientRepository clientRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<Client>> GetAll(CancellationToken token)
        {
            var result = await _clientRepository.GetAll(token);
            var resultToList = new List<Client>();

            foreach (var item in result)
            {
                resultToList.Add(_mapper.Map<Client>(item));
            }

            return resultToList;
        }

        public async Task<Client> Get(int id, CancellationToken token)
        {
            var result = await _clientRepository.Get(id, token);

            return _mapper.Map<Client>(result);
        }

        public async Task<Client> Create(Client item, CancellationToken token)
        {
            var clientEntity = _mapper.Map<ClientEntity>(item);
            var result = await _clientRepository.Create(clientEntity, token);

            return _mapper.Map<Client>(result);
        }

        public async Task<Client> Update(Client item, CancellationToken token)
        {
            var client = await _clientRepository.Get(item.Id, token);

            if (client == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var clientEntity = _mapper.Map<ClientEntity>(item);
            var result = await _clientRepository.Update(clientEntity, token);

            return _mapper.Map<Client>(result);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var client = await _clientRepository.Get(id, token);

            if (client == null)
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            await _clientRepository.Delete(id, token);
        }
    }
}
