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

        [HttpDelete]
        public IActionResult Delete()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                CreditCard GoldCard = db.CreditCards.FirstOrDefault();

                db.Remove(GoldCard);

                db.SaveChanges();              
            }

            return Ok();
        }

        [HttpPut]
        public CreditCard Update()
        {
            CreditCard updateCard = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                CreditCard GoldCard = db.CreditCards.FirstOrDefault();

                GoldCard.CardNumber = 5678;

                db.Update(GoldCard);

                db.SaveChanges();

                updateCard = db.CreditCards.FirstOrDefault(x => x.CardNumber == GoldCard.CardNumber);
            }

            return updateCard;
        }

        [HttpPost]
        public CreditCard Create()
        {
            CreditCard createCard = null;
            using (ApplicationContext db = new ApplicationContext())
            {
                CreditCard GoldCard = new CreditCard { CardNumber = 3455 };

                db.CreditCards.Add(GoldCard);

                db.SaveChanges();

                createCard = db.CreditCards.FirstOrDefault(x => x.CardNumber == GoldCard.CardNumber);
            }

            return createCard;
        }

    }
}


