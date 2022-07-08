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
            RuleFor(x=>x.SecondName).Length(1, 30);
            RuleFor(x => x.PhoneNumber).Length(9);
        }
    }
}
