using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JohnATMApps
{
    public class Database
    {
        static string location = "customer-data.txt";

        public static List<Customer> customerList = new List<Customer>();
        public static List<BankAccount> accountList = new List<BankAccount>();
        public static List<Transactions> transactionsList = new List<Transactions>();

        public static void SaveCustomerToFile()
        {
            var customerDetails = new List<string>();
            foreach (var customer in customerList)
            {
                customerDetails.Add($"{customer.Id},{customer.FullName},{customer.PhoneNumber},{customer.Email},{customer.PassWord}, {customer.AccountType}");
            }
            File.WriteAllLinesAsync(location, customerDetails);
        }

        public static async Task GetCustomerFromFile()
        {
            if (File.Exists(location))
            {
                var lines = await File.ReadAllLinesAsync(location);
                foreach (var line in lines)
                {
                    var customerDetails = line.Split(',');

                    Customer customer = new();
                    customer.Id = Convert.ToInt32(customerDetails[0]);
                    customer.FullName = customerDetails[1];
                    customer.PhoneNumber = customerDetails[2];
                    customer.Email = customerDetails[3];
                    customer.PassWord = customerDetails[4];

                    customerList.Add(customer);
                }
            }
        }
    }
}
