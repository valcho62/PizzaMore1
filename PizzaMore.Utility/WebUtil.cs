using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using PizzaMore.Data;
using PizzaMore.Models;

namespace PizzaMore.Utility
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            return Environment.GetEnvironmentVariable(Constants.RequestMethod) == "POST";
        }
        public static bool IsGet()
        {
            return Environment.GetEnvironmentVariable(Constants.RequestMethod) == "GET";
        }
        // TO DO
        public static IDictionary<string, string> RetrieveGetParameters()
        {
            var parameter = WebUtility.UrlDecode(Environment.GetEnvironmentVariable(Constants.QueryString));
            return RetriveRequiestparameters(parameter);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            var parameter = WebUtility.UrlDecode(Console.ReadLine());
            return RetriveRequiestparameters(parameter);
        }

        public static IDictionary<string, string> RetriveRequiestparameters(string parameter)
        {
            Dictionary<string,string> result = new Dictionary<string, string>();

            var paramArea = parameter.Split('&');

            foreach (var item in paramArea)
            {
                var splittedItem = item.Split('=');
                var name = splittedItem[0];
                string value = null;
                if (splittedItem.Length > 1)
                {
                    value = splittedItem[1]; 
                }
                result.Add(name,value);
            }
            return result;
        }

        public static ICookieCollection GetCookies()
        {
            var cookieHeader = Environment.GetEnvironmentVariable(Constants.CookieGet);
            var cookieCollection = new CookieCollection();

            if (string.IsNullOrEmpty(cookieHeader))
            {
                return cookieCollection;
            }

            var cookies = cookieHeader.Split(';');
            foreach (var cookie in cookies)
            {
                var cookieName = cookie.Split('=')[0];
                var cookieValue = cookie.Split('=')[1];
                var tempCookie = new Cookie()
                {
                    Name = cookieName,
                    Value = cookieValue
                };
                cookieCollection.AddCookie(tempCookie);
            }
            return cookieCollection;

        }

        public static Session GetSession()
        {
            var cookieCollection = GetCookies();
            if (!cookieCollection.ContainsKey("sid"))
            {
                return null;
            }

            PizzaMoreContex contex = new PizzaMoreContex();
            var cookieValue = cookieCollection["sid"].Value;
            //da se opravi
            var session = contex.Sessions.FirstOrDefault(x => x.Id==cookieValue);
            return session;
        }

        public static void PrintFileContent(string path)
        {
            var fileContent = File.ReadAllText(path);
            Console.WriteLine(fileContent);
        }

        public static void PageNotAllowed()
        {
            PrintFileContent("index.html");
        }
    }
}