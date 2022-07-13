namespace Bank.Models.CreditCard
{
    public class AddCreditCardViewModel
    {
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerSecondName { get; set; }
    }
}