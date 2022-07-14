namespace Bank.BLL.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public Client Client { get; set; }
    }
}
