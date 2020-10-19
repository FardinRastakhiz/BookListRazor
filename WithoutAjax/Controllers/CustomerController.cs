using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WithoutAjax.Models;

namespace WithoutAjax.Controllers
{
    public class CustomerController : Controller
    {
        private Customer customer;

        private List<Customer> customers;
        // GET: Customer
        
        public CustomerController()
        {
            customers = new List<Customer>();
            customers.Add(new Customer(0, "Fardin", 30));
            customers.Add(new Customer(1, "Bagher", 32));
            customers.Add(new Customer(2, "Ali", 29));
            customers.Add(new Customer(3, "Hamid", 35));
        }

        public ActionResult Index()
        {
            Tuple<List<Customer>, Customer> tuple;
            tuple = new Tuple<List<Customer>, Customer>(customers, customers[0]);

            return View("Customer", tuple);
        }

        [HttpPost]
        public ActionResult OnSelectCustomer(string CustomerNumber)
        {
            return PartialView("_CustomerDetails", customers[int.Parse(CustomerNumber)]);
        }
    }
}