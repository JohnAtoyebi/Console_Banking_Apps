using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnATMApps
{
    public class AccountType
    {
        public enum accountType
        {
            Savings = 1000,
            Current = 0
        }

        public enum TransactionType
        {
            Deposit,
            Withdraw,
            Transfer
        }        
    }
}
