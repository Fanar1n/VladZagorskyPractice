using Bank.Models;
using FluentValidation;

namespace Bank.Validator
{
    public class CreditCardValidator : AbstractValidator<CreditCardViewModel>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CardNumber.ToString()).Length(4, 16);
            RuleFor(x => x.CVV.ToString()).Length(3);
            RuleFor(x => x.OwnerFirstName).Length(1,30);
            RuleFor(x => x.OwnerSecondName).Length(1,30);
        }
    }
}
