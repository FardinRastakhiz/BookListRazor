using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WithoutAjax.Models
{
    public class Customer
    {
        public Customer(int id, string name, int age)
        {
            Age = age;
            Name = name;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}