using Bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;

        public CreditCardController(ILogger<CreditCardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CreditCard> Get()
        {
            IEnumerable<CreditCard> creditCards = new List<CreditCard>();

            using (ApplicationContext db = new ApplicationContext())
            {
                creditCards = db.CreditCards.ToList();
            }

            return creditCards;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                CreditCard GoldCard = db.CreditCards.FirstOrDefault(x=> x.Id==id);

                db.Remove(GoldCard);

                db.SaveChanges();              
            }

            return Ok();
        }

        [HttpPut]
        public CreditCard Update(CreditCard creditCard)
        {
            CreditCard updateCard;

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Update(creditCard);

                db.SaveChanges();

                updateCard = db.CreditCards.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);
            }

            return updateCard;
        }

        [HttpPost]
        public CreditCard Create(CreditCard creditCard)
        {
            CreditCard createCard;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.CreditCards.Add(creditCard);

                db.SaveChanges();

                createCard = db.CreditCards.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);              
            }

            return creditCard;
        }
    }
}


