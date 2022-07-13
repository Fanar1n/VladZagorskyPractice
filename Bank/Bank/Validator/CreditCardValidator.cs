﻿using Bank.Models.CreditCard;
using FluentValidation;

namespace Bank.Validator
{
    public class CreditCardValidator : AbstractValidator<AddCreditCardViewModel>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CardNumber.ToString()).Length(4, 16);
            RuleFor(x => x.CVV.ToString()).Length(3);
            RuleFor(x => x.OwnerFirstName).Length(1, 30);
            RuleFor(x => x.OwnerSecondName).Length(1, 30);
        }
    }
}
