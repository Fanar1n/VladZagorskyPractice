using System.Net;
using Bank.Models;
using FluentValidation;

namespace Bank.Validator
{
    public class ClientValidator : AbstractValidator<ClientViewModel>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).Length(1, 30);
            RuleFor(x => x.SecondName).Length(1, 30);
            RuleFor(x => x.PhoneNumber)
                .Must(IsPhoneValid).WithMessage("Номер телефона должен начинаться с +375 и содержать только цифры")
                .Length(13).WithMessage("Номер телефона должен содержать 13 символов");
        }
        private bool IsPhoneValid(string phone)
        {
            return (
                phone.StartsWith("+375")
                && phone.Substring(1).All(c => char.IsDigit(c)));
        }
    }
}
