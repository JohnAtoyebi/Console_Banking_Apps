﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JohnATMApps
{
    public class Validation
    {
        private string NameRegex = @"^[A-Z]{1}[A-Za-z]{2,}$";
        private string PhoneRegex = @"^[0-9]{11}$";
        private string PasswordRegex = @"^[a-zA-Z]{3,}[@#$%^&!]{1}[0-9]{2,}$";
        private string EmailRegex = @"^[A-Za-z0-9]+[.+-_]{0,1}[A-Za-z0-9]+[@][a-zA-Z]+[.][a-zA-Z]{2,3}$";


        public bool CheckNameInput(string name)
        {
            return Regex.IsMatch(name, NameRegex);
        }

        public bool CheckPasswordInput(string name)
        {
            return Regex.IsMatch(name, PasswordRegex);
        }

        public bool CheckEmailInput(string name)
        {
            return Regex.IsMatch(name, EmailRegex);
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.ToString().Length < 11 || phoneNumber.ToString().Length > 11)
                return false;
            return Regex.IsMatch(phoneNumber, PhoneRegex);
        }

        public (bool isDecimal, decimal Amount) CheckAmount(string amount)
        {
            return (decimal.TryParse(amount, out decimal value), value);
        }

        public (bool isLong, long Account) CheckAccountNumber(string account)
        {
            return (long.TryParse(account, out long value), value);
        }
    }
}
