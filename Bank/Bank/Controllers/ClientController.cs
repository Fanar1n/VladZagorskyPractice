using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(
            IClientService clientService,
            IMapper mapper)
        {
            _mapper = mapper;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientViewModel>> GetAll(CancellationToken token)
        {
            var result = await _clientService.GetAll(token);
            
            return _mapper.Map<IEnumerable<ClientViewModel>>(result);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken token)
        {
            await _clientService.Delete(id, token);
        }

        [HttpPut]
        public async Task<ClientViewModel> Update(ClientViewModel clientViewModel, CancellationToken token)
        {
            var client = _mapper.Map<Client>(clientViewModel);
            var result = await _clientService.Update(client, token);

            return _mapper.Map<ClientViewModel>(result);
        }

        [HttpPost]
        public async Task<ClientViewModel> Create(ClientViewModel clientViewModel, CancellationToken token)
        {
            var client = _mapper.Map<Client>(clientViewModel);
            var result = await _clientService.Create(client, token);

            return _mapper.Map<ClientViewModel>(result);
        }
    }
}
