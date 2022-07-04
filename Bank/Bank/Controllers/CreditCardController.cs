using System.Data;
using System.Linq;
using Bank.Models;
using Bank.Services;
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
        private readonly Validation _validation;

        public CreditCardController(ILogger<CreditCardController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
            _validation = new Validation(db);
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
            if (_validation.DataValidationId(id))
            {
                throw new Exception("Not correct id to delete");
            }

            var creditCard = _db.CreditCard.FirstOrDefault(x => x.Id == id);

            _db.Remove(creditCard);

            _db.SaveChanges();
        }

        [HttpPut]
        public CreditCard Update(CreditCard creditCard)
        {
            var checkCreditCard = _db.CreditCard.AsNoTracking().FirstOrDefault(p => p.Id == creditCard.Id);

            if (checkCreditCard == null
                && !_validation.DataValidationCardNumber(creditCard)
                && !_validation.DataValidationCVV(creditCard)
                && !_validation.DataValidationOwnerFirstName(creditCard)
                && !_validation.DataValidationOwnerSecondName(creditCard))
            {
                throw new ArgumentException("Data or Id is not correct");
            }

            _db.Update(creditCard);

            _db.SaveChanges();

            var updateCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return updateCard;
        }

        [HttpPost]
        public CreditCard Create(CreditCard creditCard)
        {
            if (!_validation.DataValidationCardNumber(creditCard)
                && !_validation.DataValidationCVV(creditCard)
                && !_validation.DataValidationOwnerFirstName(creditCard)
                && !_validation.DataValidationOwnerSecondName(creditCard))
            {
                throw new ArgumentException("Data is not correct");
            }

            _db.CreditCard.Add(creditCard);

            _db.SaveChanges();

            var createCard = _db.CreditCard.FirstOrDefault(x => x.CardNumber == creditCard.CardNumber);

            return createCard;
        }
    }
}