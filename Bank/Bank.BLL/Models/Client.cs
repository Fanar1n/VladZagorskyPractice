namespace Bank.BLL.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<CreditCard> CreditCard { get; set; }
    }
}
