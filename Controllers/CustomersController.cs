using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private Model1 db = new Model1();

        public ActionResult AllCustomers()
        {

            var customers = db.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        public ActionResult New()
        {

            var membershipTypes = db.MembershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                MembershipTypes = membershipTypes,

            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
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


    }
}