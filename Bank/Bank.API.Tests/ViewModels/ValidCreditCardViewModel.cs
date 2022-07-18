using Bank.Models.CreditCard;

namespace Bank.API.Tests.Models
{
    public static class ValidCreditCardViewModel
    {
        public static IEnumerable<CreditCardViewModel> InitListCreditCards = new List<CreditCardViewModel>
        {
            new() { Id = 1,
                CardNumber = 4444,
                CVV = 444,
                Client = new() {FirstName = "Vlad", SecondName = "Zagosrky", PhoneNumber = "+375293710904"}}
        };

        public static CreditCardViewModel CreditCardViewModel = new()
        {
            CardNumber = 4444,
            CVV = 444,
            Client = new() { FirstName = "Vlad", SecondName = "Zagosrky", PhoneNumber = "+375293710904" }
        };

        public static AddCreditCardViewModel AddCreditCardViewModel = new()
        {
            CardNumber = 6666,
            CVV = 666,
            ClientId = 1
        };

        public static ShortCreditCardViewModel ShortCreditCardViewModel = new()
        {
            CardNumber = 6666,
            CVV = 666,
            Client = new() { FirstName = "Vlad", SecondName = "Zagorsky", PhoneNumber = "+375293710904" }
        };

        public static UpdateCreditCardViewModel UpdateCreditCardViewModel = new()
        {
            Id = 1,
            CardNumber = 6666,
            CVV = 666,
            ClientId = 1
        };
    }
}