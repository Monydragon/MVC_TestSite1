using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer() { }

        public Customer(string name)
        {
            Name = name;
        }
    }
}