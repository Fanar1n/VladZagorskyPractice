using Bank.BLL.Interfaces;
using Bank.Mappers;
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

        public CreditCardController(ILogger<CreditCardController> logger, ICreditCardServices creditCardServices)
        {
            _logger = logger;
            _creditCardServices = creditCardServices;
        }

        [HttpGet]
        public IEnumerable<CreditCardViewModel> GetAll()
        {
            var result = _creditCardServices.GetAll();

            var resultToList = new List<CreditCardViewModel>();

            foreach (var item in result)
            {
                resultToList.Add(Mapper.ConvertCreditCardToCreditCardViewModel(item));
            }

            return resultToList;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _creditCardServices.Delete(id);
        }

        [HttpPut]
        public CreditCardViewModel Update(CreditCardViewModel creditCardViewModel)
        {
            var creditCard = Mapper.ConvertCreditCardViewModelToCreditCard(creditCardViewModel);

            var result = _creditCardServices.Update(creditCard);

            return Mapper.ConvertCreditCardToCreditCardViewModel(result);
        }

        [HttpPost]
        public CreditCardViewModel Create(CreditCardViewModel creditCardViewModel)
        {
            var creditCard = Mapper.ConvertCreditCardViewModelToCreditCard(creditCardViewModel);

            var result = _creditCardServices.Create(creditCard);

            return Mapper.ConvertCreditCardToCreditCardViewModel(result);
        }
    }
}