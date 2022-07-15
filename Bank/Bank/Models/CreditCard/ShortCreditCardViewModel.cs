using Bank.Models.Client;

namespace Bank.Models.CreditCard
{
    public class ShortCreditCardViewModel
    {
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public ClientViewModel Client { get; set; }
    }
}
