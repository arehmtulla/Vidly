using System.Collections.Generic;
<<<<<<< HEAD
using System.Web.Mvc;
using Vidly.Models;
=======
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        public ActionResult AllCustomers()
        {
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = db.Genres.ToList();
            }

<<<<<<< HEAD
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Abdul"},
                new Customer { Id = 2, Name = "Mary"}
            };
            return View(customers);
=======
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            return View();
>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525
        }


        public ActionResult Customer(int id, string name)
        {
            var customer = new Customer { Id = id, Name = name };
            return View(customer);
        }
<<<<<<< HEAD
=======

        public ActionResult New()
        {

            var membershipTypes = db.MembershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new FormCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            db.SaveChanges();
            return RedirectToAction("AllCustomers", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new FormCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList(),
            };

            return View("CustomerForm", viewModel);
        }


>>>>>>> 0dc5fc4abdb3499de42248cddfb94b2a22ab5525
    }
}