using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PizzaciPractice.Class
{
    public class Employee
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Employee()
        {
                
        }

        public Employee(int ıd, string name, string surname, string username, string password, string email, int age)
        {
            Id = ıd;
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
            Age = age;
        }

        public Employee(string name, string surname, string username, string password, string email, int age)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            Email = email;
            Age = age;
        }



        public int DogumGunu()
        {
            this.Age++;

            return Age;
        }

    }
}
