using System;
using System.IO;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Models;
using PizzaMore.Utility;


namespace PizzaMore.SignIn
{
    class Program
    {
        static void Main()
        {
            if (WebUtil.IsGet())
            {
                Header.Print();
                var signupPage = File.ReadAllText("C:/xampp/htdocs/pm/signin.html");
                Console.WriteLine(signupPage);
            }
            else if (WebUtil.IsPost())
            {
                var parameters = WebUtil.RetrievePostParameters();
                var user = parameters["user"];
                var password = parameters["password"];
                password = PasswordHasher.Hash(password);
                PizzaMoreContex contex = new PizzaMoreContex();
                var searchUser = contex.Users.FirstOrDefault(x => x.Email == user);

                if (searchUser.Password == password)
                {
                    contex.Sessions.Add(new Session() {User = searchUser,UserId = searchUser.Id});
                    contex.SaveChanges();
                }
            }
        }
    }
}
