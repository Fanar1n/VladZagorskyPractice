using Bank.Models.CreditCard;

namespace Bank.API.Tests.Models
{
    public static class ValidCreditCardViewModel
    {
        public static IEnumerable<CreditCardViewModel> InitListCreditCards = new List<CreditCardViewModel>
        {
            new() { Id = 1, CardNumber = 4444, CVV = 444, OwnerFirstName = "Vlad" , OwnerSecondName = "Zagorsky"}
        };

        public static CreditCardViewModel CreditCardViewModel = new()
        {
            CardNumber = 4444,
            CVV = 444,
            OwnerFirstName = "Vlad",
            OwnerSecondName = "Zagorsky"
        };

        public static AddCreditCardViewModel AddCreditCardViewModel = new()
        {
            CardNumber = 6666,
            CVV = 666,
            OwnerFirstName = "Dimon",
            OwnerSecondName = "Dimoooon"
        };

        public static ShortCreditCardViewModel ShortCreditCardViewModel = new()
        {
            CardNumber = 6666,
            CVV = 666,
            OwnerFirstName = "Dimon",
            OwnerSecondName = "Dimoooon"
        };
    }
}