using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        public ActionResult AllCustomers()
        {

            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Abdul"},
                new Customer { Id = 2, Name = "Mary"}
            };
            return View(customers);
        }


        public ActionResult Customer(int id, string name)
        {
            var customer = new Customer { Id = id, Name = name };
            return View(customer);
        }
    }
}