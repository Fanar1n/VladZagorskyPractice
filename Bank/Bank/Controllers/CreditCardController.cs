using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {



        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CreditCard> Get()
        {
            IEnumerable<CreditCard> creditCards = new List<CreditCard>();

            using (Bank.Models.ApplicationContext db = new Bank.Models.ApplicationContext())
            {
                CreditCard GoldCard = new CreditCard { CardNumber = 6666666666666666 };

                db.CreditCards.Add(GoldCard);
                db.SaveChanges();

                creditCards = db.CreditCards.ToList();
            }

            return creditCards;
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            using (Bank.Models.ApplicationContext db = new Bank.Models.ApplicationContext())
            {
                CreditCard GoldCard = new CreditCard { CardNumber = 6666666666666666 };

                db.CreditCards.Add(GoldCard);

                db.SaveChanges();

                db.Remove(GoldCard);

                db.SaveChanges();              
            }

            return Ok();
        }

        [HttpPut]
        public CreditCard Update()
        {
            CreditCard updateCard = null;
            using (Bank.Models.ApplicationContext db = new Bank.Models.ApplicationContext())
            {
                CreditCard GoldCard = new CreditCard { CardNumber = 6666666666666666 };

                db.CreditCards.Add(GoldCard);

                db.SaveChanges();

                GoldCard.CardNumber = 8888888888888888;

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
            using (Bank.Models.ApplicationContext db = new Bank.Models.ApplicationContext())
            {
                CreditCard GoldCard = new CreditCard { CardNumber = 6666666666666666 };

                db.CreditCards.Add(GoldCard);

                db.SaveChanges();

                createCard = db.CreditCards.FirstOrDefault(x => x.CardNumber == GoldCard.CardNumber);
            }

            return createCard;
        }

    }
}


