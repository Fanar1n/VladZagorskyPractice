using Bank.Models.Client;
using FluentValidation;

namespace Bank.Validator
{
    public class ClientValidator : AbstractValidator<AddClientViewModel>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 30);
            RuleFor(x => x.SecondName).Length(1, 30);
            RuleFor(x => x.PhoneNumber)
                .Must(IsPhoneValid).WithMessage("The phone number must start with +375 and contain only digits")
                .Length(13).WithMessage("The phone number must contain 13 characters");
        }
        private bool IsPhoneValid(string phone)
        {
            return (
                phone.StartsWith("+375")
                && phone.Substring(1).All(c => char.IsDigit(c)));
        }
    }
}
