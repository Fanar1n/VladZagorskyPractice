
namespace Bank.Models.CreditCard
{
    public class UpdateCreditCardViewModel
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public int ClientId { get; set; }
    }
}
