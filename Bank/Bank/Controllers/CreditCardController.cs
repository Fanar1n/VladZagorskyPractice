using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;


namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly ICreditCardServices _creditCardServices;
        private readonly IMapper _mapper;

        public CreditCardController(
            ILogger<CreditCardController> logger, 
            ICreditCardServices creditCardServices, 
            IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _creditCardServices = creditCardServices;
        }

        [HttpGet]
        public async Task<IEnumerable<CreditCardViewModel>> GetAll()
        {
            var result = await _creditCardServices.GetAll();

            var resultToList = new List<CreditCardViewModel>();

            foreach (var item in result)
            {
                resultToList.Add(_mapper.Map<CreditCardViewModel>(item));
            }

            return resultToList;
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _creditCardServices.Delete(id);
        }

        [HttpPut]
        public async Task<CreditCardViewModel> Update(CreditCardViewModel creditCardViewModel)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardViewModel);

            var result = await _creditCardServices.Update(creditCard);

            return _mapper.Map<CreditCardViewModel>(result);
        }

        [HttpPost]
        public async Task<CreditCardViewModel> Create(CreditCardViewModel creditCardViewModel)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardViewModel);

            var result = await _creditCardServices.Create(creditCard);

            return _mapper.Map<CreditCardViewModel>(result);
        }
    }
}