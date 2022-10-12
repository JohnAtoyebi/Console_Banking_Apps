using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnATMApps
{
    public class Customer
    {
        public int Id { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string AccountType { get; set; }
        public string PhoneNumber { get; set; }


        public Customer(int id, string fullname, string email, string password, string acctType, string phone)
        {
            FullName = fullname;
            Email = email;
            PassWord = password;
            AccountType = acctType;
            PhoneNumber = phone;
            Id = id;
        }

        public Customer()
        {
        }
    }
}
