using AutoMapper;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Models.CreditCard;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardServices _creditCardServices;
        private readonly IMapper _mapper;

        public CreditCardController(
            ICreditCardServices creditCardServices,
            IMapper mapper)
        {
            _mapper = mapper;
            _creditCardServices = creditCardServices;
        }

        [HttpGet]
        public async Task<IEnumerable<CreditCardViewModel>> GetAll(CancellationToken token)
        {
            var result = await _creditCardServices.GetAll(token);

            return _mapper.Map<IEnumerable<CreditCardViewModel>>(result);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken token)
        {
            await _creditCardServices.Delete(id, token);
        }

        [HttpPut]
        public async Task<CreditCardViewModel> Update(CreditCardViewModel creditCardViewModel, CancellationToken token)
        {
            var creditCard = _mapper.Map<CreditCard>(creditCardViewModel);
            var result = await _creditCardServices.Update(creditCard, token);

            return _mapper.Map<CreditCardViewModel>(result);
        }

        [HttpPost]
        public async Task<ShortCreditCardViewModel> Create(AddCreditCardViewModel addCreditCardViewModel, CancellationToken token)
        {
            var creditCard = _mapper.Map<CreditCard>(addCreditCardViewModel);
            var result = await _creditCardServices.Create(creditCard, token);

            return _mapper.Map<ShortCreditCardViewModel>(result);
        }
    }
}