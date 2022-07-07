using Bank.Models;
using FluentValidation;

namespace Bank.Validator
{
    public class CreditCardValidator : AbstractValidator<CreditCardViewModel>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CardNumber).InclusiveBetween(1, 99999);
            RuleFor(x => x.CVV).InclusiveBetween(1, 999);
            RuleFor(x => x.OwnerFirstName).Length(1,30);
            RuleFor(x => x.OwnerSecondName).Length(1,30);
        }
    }
}
