using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL.Models
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
