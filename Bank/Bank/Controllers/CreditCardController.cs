using System.Data;
using System.Linq;
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
        public IActionResult Delete(int id)
        {
            var checkCreditCard = _db.CreditCard.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (checkCreditCard != null)
            {
                CreditCard creditCard = _db.CreditCard.FirstOrDefault(x => x.Id == id);

                _db.Remove(creditCard);

                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Not correct id to delete");
            }

            return Ok();
        }

        [HttpPut]
        public CreditCard Update(CreditCard creditCard)
        {
            var checkCreditCard = _db.CreditCard.AsNoTracking().FirstOrDefault(p => p.Id == creditCard.Id);

            if (checkCreditCard != null && DataValidation(creditCard))
            {
                _db.Update(creditCard);

                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            var updateCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return updateCard;
        }

        [HttpPost]
        public CreditCard Create(CreditCard creditCard)
        {
            if (DataValidation(creditCard))
            {
                _db.CreditCard.Add(creditCard);

                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Data is not correct");
            }

            var createCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return createCard;
        }

        private bool DataValidation(CreditCard creditCard)
        {
            return creditCard.CardNumber.ToString().Length >= 4
                   && creditCard.CardNumber.ToString().Length <= 6
                   && creditCard.CVV.ToString().Length == 3
                   && creditCard.OwnerFirstName.Length > 0
                   && creditCard.OwnerFirstName.Length <= 30
                   && creditCard.OwnerSecondName.Length > 0
                   && creditCard.OwnerSecondName.Length <= 30;
        }

        private bool IsCorrectId(int id)
        {
            bool correctId = false;

            foreach (var creditCard in _db.CreditCard)
            {
                if (creditCard.Id == id)
                {
                    correctId = true;
                }
                else
                {
                    throw new Exception("Not correct id to update");
                }
            }

            return correctId;
        }
    }
}