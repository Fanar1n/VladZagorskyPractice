using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly ApplicationContext _db;

        public CreditCardController(ILogger<CreditCardController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<CreditCard> Get()
        {
            var creditCards = _db.CreditCard.ToList();

            return creditCards;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var creditCard = _db.CreditCard.FirstOrDefault(x => x.Id == id);

            _db.Remove(creditCard);

            _db.SaveChanges();
        }

        [HttpPut]
        public CreditCard Update(CreditCard creditCard)
        {

            _db.Update(creditCard);

            _db.SaveChanges();

            var updateCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return updateCard;
        }

        [HttpPost]
        public CreditCard Create(CreditCard creditCard)
        {
            _db.CreditCard.Add(creditCard);

            _db.SaveChanges();

            var createCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return createCard;
        }
    }
}