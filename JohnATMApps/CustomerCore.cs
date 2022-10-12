using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnATMApps
{
    public class CustomerCore
    {
        Customer customerInput;
        private int id = 001;
        public long accountNumber = 1211010120;

        public bool Login(string email, string password)
        {
            if (Database.customerList == null)
                return false;
            else
            {
                var verify = Database.customerList.Exists(
                    user => user.Email == email && user.PassWord == password);
                if (verify)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public void CustomerRegistration(string fullname, string email, string password, string acctType, string phoneNumber)
        {
            customerInput = new Customer(id, fullname, email, password, acctType, phoneNumber);
            Database.customerList.Add(customerInput);
            Database.SaveCustomerToFile();
        }

        public string GetName(string email, string password)
        {
            string name = string.Empty;
            foreach (var user in Database.customerList)
            {
                if (user.Email.Equals(email) && user.PassWord.Equals(password))
                {
                    name = user.FullName;
                }
            }
            return name;
        }
    }
}
