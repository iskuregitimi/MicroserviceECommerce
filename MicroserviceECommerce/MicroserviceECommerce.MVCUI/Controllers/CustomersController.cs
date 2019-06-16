using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI.HttpHelpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult GetAllCustomers()
        {
            List<Customer> customerList = HttpHelperMethods.GetAll<List<Customer>>("http://localhost:37776", "api/Customers", Method.GET);
            return View(customerList);
        }

        public ActionResult GetCustomerWithId(string Id)
        {
            Customer customer = HttpHelperMethods.GetWithId<Customer>("http://localhost:37776", "api/Customers", Method.GET, Id);
            return View(customer);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            HttpHelperMethods.Add<Customer>("http://localhost:37776", "api/Customers", Method.POST, customer);
            return RedirectToAction("GetAllCustomers");
        }
        [HttpGet]
        public ActionResult EditCustomer(string Id)
        {
            Customer customer = HttpHelperMethods.GetWithId<Customer>("http://localhost:37776", "api/Customers", Method.GET, Id);
            return View(customer);
        }
        [HttpPost]
      public ActionResult EditCustomer(Customer customer, string Id)
        {
            HttpHelperMethods.Edit<Customer>("http://localhost:37776", "api/Customers", Method.POST, customer, Id);
            return RedirectToAction("GetAllCustomers");
        }
        public ActionResult DeleteCustomer(Customer customer, string Id)
        {
            HttpHelperMethods.Delete<Customer>("http://localhost:37776", "api/Customers", Method.DELETE, Id);
            return RedirectToAction("GetAllCustomers");
        }


    }
}