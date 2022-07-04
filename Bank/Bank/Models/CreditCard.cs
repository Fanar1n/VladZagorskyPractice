namespace Bank
{
    public class CreditCard
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public int CVV { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerSecondName { get; set; }
    }
}