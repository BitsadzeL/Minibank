using Minibank.Models;

namespace Minibank
{
    internal class Program
    {
        //1. მოახდინეთ Account ების და Customer ების Mapping
        //2.დაწერეთ ფუნქციონალი რომელიც მისცემს საშუალებას Customer- ს რომ გაიაროს რეგისტრაცია და გახსნას ახალი ანაგარიში ბანკში.
        static void Main(string[] args)
        {
            string[] customersInputCSV = File.ReadAllLines(@"../../../Customers.csv");
            string[] accountInputCSV = File.ReadAllLines(@"../../../Accounts.csv");

            
            List<User> usersList = User.parseUsers(customersInputCSV);
            List<Account> accountList = Account.parseAccounts(accountInputCSV);


            
            foreach (var user in usersList)
            {           
                foreach (var acc in accountList)
                {
                    if (acc.Customerid == user.Id) 
                    {
                        user.accounts.Add(acc); 
                    }
                }
            }



            foreach (var user in usersList)
            {
                Console.WriteLine(user.ToString());
                foreach (var account in user.accounts)
                {
                    Console.WriteLine($"  Account info: {account.ToString()}");
                }
            }

  

        }
    }
}
