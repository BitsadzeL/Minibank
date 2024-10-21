using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Models
{
    //Id,Iban,Currency,Balance,CustomerId,Name
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public int Customerid { get; set; }
        public string Name { get; set; }

        public Account(int id, string iban, string curr, double bal, int customerid,string name)
        {
            Id=id;
            Iban = iban;
            Currency = curr;
            Balance = bal;
            Customerid= customerid;
            Name = name;
        }

        public Account(string iban, string curr, double bal) {
            Iban = iban;
            Currency = curr;
            Balance = bal;
        
        }

        public override string ToString()
        {
            return $"{Id} {Iban} {Currency} {Balance} {Customerid} {Name}";
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
                Account accObj = new Account(id,iban,currency,balance,customerid,name);
                result.Add(accObj);

            }
            return result;
        }
    }
}
