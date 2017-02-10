using System;
using System.IO;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility;

namespace PizzaMore.SignUp
{
    class Program
    {
        static void Main()
        {
            if (WebUtil.IsGet())
            {
                var signupPage = File.ReadAllText("../../htdocs/pm/signup.html");
                Console.WriteLine(signupPage);
            }
            else if (WebUtil.IsPost())
            {
                var parameters = WebUtil.RetrievePostParameters();
                var user = parameters["user"];
                var password = parameters["password"];
                password = PasswordHasher.Hash(password);
                PizzaMoreContex contex = new PizzaMoreContex();
                contex.Users.Add(new User() {Email = user, Password = password});
                contex.SaveChanges();
            }
        }
    }
}
