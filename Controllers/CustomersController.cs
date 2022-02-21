using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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

            return View();
        }


    }
}