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




            //foreach (User user in usersList)
            //{

            //    User userobj = new User(user.Name, user.Id);                
            //    List<Account> userAccounts = new List<Account>();

            //    foreach (Account account in accountList)
            //    {
            //        if (account.Customerid == user.Id)
            //        {

            //            Account accObj = new Account(account.Iban, account.Currency, account.Balance);

            //            userAccounts.Add(accObj);
            //        }
            //    }
            //       usersAndAccs[userobj] = userAccounts;     
            //}



            //foreach (var entry in usersAndAccs)
            //{   
            //    Console.WriteLine($"User: {entry.Key.Name}, Id: {entry.Key.Id}"); 

            //    foreach (var account in entry.Value)
            //    {
            //        Console.WriteLine($"  Account Iban: {account.Iban}, Balance:{account.Balance}  {account.Currency}");
            //    }
            //}





        }
    }
}
