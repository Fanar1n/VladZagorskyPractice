using Bank.Models.Client;

namespace Bank.Models.CreditCard
{
    public class AddCreditCardViewModel
    {
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public ClientViewModel ClientViewModel { get; set; }
    }
}