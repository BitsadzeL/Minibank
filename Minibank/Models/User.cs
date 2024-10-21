using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Models
{
    //Id,Name,IdentityNumber,PhoneNumber,Email,Type
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

        public override string ToString() 
        {
            return $"{Name}";
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



    }
}
