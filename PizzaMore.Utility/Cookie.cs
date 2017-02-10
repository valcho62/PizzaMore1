﻿namespace PizzaMore.Utility
{
    public class Cookie
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Cookie()
        {
            Name = null;
            Value = null;
        }

        public Cookie(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{this.Name}={this.Value}";
        }
    }
}