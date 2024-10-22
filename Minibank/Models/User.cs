using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Models
{
    
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public List<Account> accounts { get; set; }=new List<Account>();

        public User(int id, string name, string idnumber,string phone, string email, int type) 
        {
            Id = id;
            Name = name;
            IdentityNumber = idnumber;
            PhoneNumber = phone;
            Email = email;
            Type = type;
        }


        public User(int id, string name, string idnumber, string phone, string email, int type, Account acc)
        {
            Id= id;
            Name = name;
            IdentityNumber= idnumber;
            PhoneNumber = phone;
            Email = email;
            Type = type;
            accounts.Add(acc);

        }

        public User() { }

        public override string ToString() 
        {
            return $"{Name}";
        }
        public string allData()
        {
            return $"{Name} {IdentityNumber} {PhoneNumber} {Email} " +
                $"{accounts.Count}";
        }

        public static List<User> parseUsers(string[] input)
        {
            List<User> result = new List<User>();
            for (int i = 1; i < input.Length; i++)
            {
                string[] data = input[i].Split(',');
                int id = Convert.ToInt32 (data[0]);
                string name = data[1];
                string idnumber = data[2];
                string phone = data[3];
                string email = data[4];
                int type = Convert.ToInt32(data[5]);
                User userObj = new User(id,name,idnumber,phone,email,type);
                result.Add(userObj);

            }
            return result;
        }

        public string UserDataToCSV()
        {
            return $"{Id},{Name},{IdentityNumber},{PhoneNumber},{Email},{Type}";
        }

        public static List<User> mapAccsAndUsers(List<User> usersList, List<Account> accountList) 
        {
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

            return usersList;

        }


        public static void showUsersAndAccs(List<User> usersList)
        {
            foreach (var user in usersList)
            {
                Console.WriteLine(user.ToString());
                foreach (var account in user.accounts)
                {
                    Console.WriteLine($"  Account info: {account.ToString()}");
                }
            }
        }




        public static User CreateNewUser(List<User> usersList)
        {
            int id = usersList.Count > 0 ? usersList[usersList.Count - 1].Id + 1 : 1;

            Console.WriteLine("Enter your name and surname: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your identity number: ");
            string idnumber = Console.ReadLine();

            Console.WriteLine("Enter your phone number: ");
            string number = Console.ReadLine();

            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter account type (for physical 0/for LTD 1): ");
            int type = Convert.ToInt16(Console.ReadLine());

            User newUser = new User(id, name, idnumber, number, email, type);

            File.AppendAllText(@"../../../Customers.csv", $"{newUser.UserDataToCSV()}{Environment.NewLine}");

            return newUser;
        }




    }
}
