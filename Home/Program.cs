
using System;
using System.Collections.Generic;
using System.IO;
using PizzaMore.Utility;
using PizzaMore.Data;
using PizzaMore.Models;

namespace Home
{
    public class Home
    {
        private static IDictionary<string, string> RequestParameters;
        private static Session Session;
        private static Header Header = new Header();
        private static string Language;



        public static void Main()
        {
            //var contex = new PizzaMoreContex();
            //contex.Database.Initialize(true);

            AddDefaultLanguageCookie();

            if (WebUtil.IsGet())
            {
                RequestParameters = WebUtil.RetrieveGetParameters();
                TryLogOut();
                Language = WebUtil.GetCookies()["lang"].Value;
            }
            else if (WebUtil.IsPost())
            {
                RequestParameters = WebUtil.RetrievePostParameters();
                Header.AddCookie(new Cookie("lang", RequestParameters["language"]));
                Language = RequestParameters["language"];
            }
            ShowPage();
        }

        private static void ShowPage()
        {
            Header.Print();
            if (Language == "EN")
            {
                ServeEnPage();
            }
            else
            {
                ServeBGPage();

            }

            

        }

        private static void ServeBGPage()
        {
            var homePage = File.ReadAllText("C:/xampp/htdocs/pm/homeBg.html");
           
            Console.WriteLine(homePage);
        }

        private static void ServeEnPage()
        {
            var homePage = File.ReadAllText("C:/xampp/htdocs/pm/home.html");
            
            Console.WriteLine(homePage);
        }

        public static void AddDefaultLanguageCookie()
        {
            if (!WebUtil.GetCookies().ContainsKey("lang"))
            {
                Header.AddCookie(new Cookie("lang", "EN"));
                Language = "EN";
                ShowPage();
            };

        }

        private static void TryLogOut()
        {
           
        }
    }
    
}

