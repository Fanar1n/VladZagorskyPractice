using Bank.Models.CreditCard;

namespace Bank.Models.Client
{
    public class ShortClientViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<CreditCardViewModel> creditCardViewModel { get; set; }
    }
}
