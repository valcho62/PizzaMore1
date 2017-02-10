using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Utility
{
    public class CookieCollection :ICookieCollection
    {
        public IDictionary<string,Cookie> Cookies { get; set; }

        public CookieCollection()
        {
            this.Cookies = new Dictionary<string, Cookie>();
        }
        public void AddCookie(Cookie cookie)
        {
            if (! this.Cookies.ContainsKey(cookie.Name))
            {
                this.Cookies.Add(cookie.Name, cookie); 
            }
            this.Cookies[cookie.Name] = cookie;
        }

        public void RemoveCookie(string cookieName)
        {
            if (this.Cookies.ContainsKey(cookieName))
            {
                this.Cookies.Remove(cookieName); 
            }
        }

        public bool ContainsKey(string key)
        {
            return this.Cookies.ContainsKey(key);
        }

        public int Count { get { return this.Cookies.Count; } }

        public Cookie this[string key]
        {
            get { return this.Cookies[key]; }
            set
            {
                if (this.Cookies.ContainsKey(key))
                {
                     this.Cookies[key] = value;
                }
                else
                {
                    this.Cookies.Add(key,value);
                }
               
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
        IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
        {
            return this.Cookies.Values.GetEnumerator();
        }
    }
}