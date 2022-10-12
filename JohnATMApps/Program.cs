using System;

namespace JohnATMApps
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.GetCustomerFromFile().GetAwaiter();
            DisplayUI displayUI = new DisplayUI();
            displayUI.StartUI();
        }
    }
}
