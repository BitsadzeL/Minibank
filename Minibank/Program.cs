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


            usersList=User.mapAccsAndUsers(usersList, accountList);
            //User.showUsersAndAccs(usersList);



            Console.WriteLine("For registration enter 1, to add a new account enter 2");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                    User newUser = User.CreateNewUser(usersList);
                    Account newAccount = Account.CreateNewAccount(accountList, newUser.Id);
                    newUser.accounts.Add(newAccount);
                

            }

            else if (choice == 2)
            {
                Console.WriteLine("Enter your identity number: ");
                string identitynumber = Console.ReadLine();
                User user = null;
                foreach (var data in usersList)
                {
                    if (data.IdentityNumber == identitynumber)
                    {
                        user = data;

                    }

                }
                Account newAcc = Account.CreateNewAccount(accountList, user.Id);
                user.accounts.Add(newAcc);
            }



            //User.showUsersAndAccs(usersList);

        }
    }
}
