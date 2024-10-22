using System;
using System.Collections.Generic;
using System.IO;

namespace Minibank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public int Customerid { get; set; }
        public string Name { get; set; }

        public Account(int id, string iban, string curr, double bal, int customerid, string name)
        {
            Id = id;
            Iban = iban;
            Currency = curr;
            Balance = bal;
            Customerid = customerid;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} {Iban} {Currency} {Balance} {Name}";
        }

        public static List<Account> parseAccounts(string[] input)
        {
            List<Account> result = new List<Account>();
            for (int i = 1; i < input.Length; i++)
            {
                string[] data = input[i].Split(',');
                int id = Convert.ToInt32(data[0]);
                string iban = data[1];
                string currency = data[2];
                double balance = Convert.ToDouble(data[3]);
                int customerid = Convert.ToInt32(data[4]);
                string name = data[5];
                Account accObj = new Account(id, iban, currency, balance, customerid, name);
                result.Add(accObj);
            }
            return result;
        }

        public static string GenerateIBAN()
        {
            string countryCode = "GE";
            string checkDigits = GenerateRandomCheckDigits();
            string bankCode = "SB185472";
            string accountNumber = GenerateRandomAccountNumber(12);
            string iban = $"{countryCode}{checkDigits}{bankCode}{accountNumber}";
            return iban;
        }

        private static string GenerateRandomCheckDigits()
        {
            Random random = new Random();
            int checkDigits = random.Next(0, 100);
            return checkDigits.ToString("00");
        }

        private static string GenerateRandomAccountNumber(int length)
        {
            Random random = new Random();
            string accountNumber = "";
            for (int i = 0; i < length; i++)
            {
                accountNumber += random.Next(0, 10);
            }
            return accountNumber;
        }

        public string accountDataToCSV()
        {
            return $"{Id},{Iban},{Currency},{Balance},{Customerid},{Name}";
        }

        public static Account CreateNewAccount(List<Account> accountList, int customerId)
        {
            int accId = accountList.Count > 0 ? accountList[^1].Id + 1 : 1;

            string iban = Account.GenerateIBAN();
            Console.WriteLine($"Your account IBAN code: {iban}");

            Console.WriteLine("Enter currency you want your account to be opened in: ");
            string curr = Console.ReadLine();

            Console.WriteLine("Enter deposit (if you do not want to make a deposit, enter 0): ");
            double bal = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter destination for your account (you can leave it empty by clicking enter): ");
            string dest = Console.ReadLine();

            Account accObj = new Account(accId, iban, curr, bal, customerId, dest);
            File.AppendAllText(@"../../../Accounts.csv", $"{accObj.accountDataToCSV()}{Environment.NewLine}");

            return accObj;
        }
    }
}
