using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace JohnATMApps
{
    public class BankAccountCore
    {
        private int id = 100;
        string description = "Amount deposited after opening of account";
        string transactionType = AccountType.TransactionType.Deposit.ToString();
        string savingAccountType = AccountType.accountType.Savings.ToString();
        string currentAccountType = AccountType.accountType.Current.ToString();


        public void CreateBankAccount(string accountName, decimal initialBalance, string accountType,
            long accountNumber)
        {
            BankAccount bankAccount = new BankAccount(id, initialBalance, accountType,
                accountNumber, accountName);
            Database.accountList.Add(bankAccount);
            Transactions transactions = new Transactions(initialBalance, initialBalance, description,
                DateTime.Now.ToString(), transactionType, accountNumber);
            Database.transactionsList.Add(transactions);
            id++;
        }


        public string GetAccountType(string name)
        {
            foreach (BankAccount bankAccount in Database.accountList)
            {
                if (bankAccount.AccountName == name)
                {
                    return bankAccount.AccountType;
                }
            }
            return "No AccountType for this user";
        }


        public long GetAccountNumberByName(string name)
        {
            foreach (BankAccount bankAccount in Database.accountList)
            {
                if (bankAccount.AccountName == name)
                {
                    return bankAccount.AccountNumber;
                }
            }
            return 0;
        }


        public bool CheckAccountNumberIfExists(long accountNumber)
        {
            foreach (BankAccount bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    return true;
                }
            }
            return false;
        }


        public bool MakeWithdraw(string transactionType, decimal amount,
            string description, long accountNumber)
        {
            decimal Balance = 0;
            foreach (var bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == accountNumber && bankAccount.AccountType == savingAccountType
                    && bankAccount.Balance - amount >= 1000)
                {
                    Balance = bankAccount.Balance - amount;
                    bankAccount.Balance = Balance;
                    return true;
                }
            }
            Transactions transactions = new Transactions(amount, Balance, description,
                DateTime.Now.ToString(), transactionType, accountNumber);
            Database.transactionsList.Add(transactions);
            return false;
        }


        public void MakeDeposit(string transactionType, decimal amount,
            string description, long accountNumber)
        {
            decimal Balance = 0;
            foreach (var bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    Balance = bankAccount.Balance + amount;
                    bankAccount.Balance = Balance;
                }
            }
            Transactions transactions = new Transactions(amount, Balance, description,
                DateTime.Now.ToString(), transactionType, accountNumber);
            Database.transactionsList.Add(transactions);
        }


        public bool MakeTransfer(string transactionType, decimal amount,
            string description, long debitAccountNumber, long creditAccountNumber)
        {
            decimal Balance = 0;
            foreach (var bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == debitAccountNumber && bankAccount.AccountType == savingAccountType && bankAccount.AccountType == currentAccountType
                    && bankAccount.Balance - amount >= 1000)
                {
                    Balance = bankAccount.Balance + amount;
                    bankAccount.Balance = Balance;
                    return true;
                }
            }
            Transactions transactions = new Transactions(amount, Balance, description,
                DateTime.Now.ToString(), transactionType, debitAccountNumber);
            Database.transactionsList.Add(transactions);
            foreach (var bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == creditAccountNumber)
                {
                    Balance = bankAccount.Balance + amount;
                    bankAccount.Balance = Balance;
                }
            }
            Transactions creditTransactions = new Transactions(amount, Balance, description,
                DateTime.Now.ToString(), transactionType, creditAccountNumber);
            Database.transactionsList.Add(creditTransactions);
            return false;
        }


        public decimal GetBalance(long accountNumber)
        {
            foreach (BankAccount bankAccount in Database.accountList)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    return bankAccount.Balance;
                }
            }
            return 0;
        }
    }
}
