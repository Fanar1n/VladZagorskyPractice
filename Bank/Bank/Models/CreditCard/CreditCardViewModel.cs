using Bank.Models.Client;

namespace Bank.Models.CreditCard
{
    public class CreditCardViewModel
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public ClientViewModel ClientViewModel { get; set; }
    }
}
