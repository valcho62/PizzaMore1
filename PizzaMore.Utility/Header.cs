using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMore.Utility
{
    public class Header
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public ICookieCollection Cookies { get; set; }

        public Header()
        {
            Type = "Content-type: text/html";
            Cookies = new CookieCollection();
        }

        public void AddLocation(string location)
        {
            this.Location = $"Location: {location}";
        }

        public void AddCookie(Cookie cookie)
        {
            this.Cookies.AddCookie(cookie);
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.Type);
            if (this.Cookies != null)
            {
                foreach (var cooki in Cookies)
                {

                    sb.AppendLine($"Set-Cookie: {cooki.ToString()}");
                    if (this.Location != null)
                    {
                        sb.AppendLine(this.Location);
                    }

                }
            }
            sb.Append("\n\r\n\r");
            return sb.ToString();
        }
    }
}