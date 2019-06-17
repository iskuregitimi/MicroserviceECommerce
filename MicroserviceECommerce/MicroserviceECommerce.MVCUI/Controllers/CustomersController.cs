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
            List<Customer> customerList = HttpHelperMethods.GetAll<List<Customer>>("http://localhost:37776", "api/Customers/GetAll", Method.GET);
            return View(customerList);
        }

        public ActionResult GetCustomerWithId(string Id)
        {
            Customer customer = HttpHelperMethods.GetWithId<Customer>("http://localhost:37776", "api/Customers/GetWithId", Method.GET, Id);
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
            HttpHelperMethods.Add<Customer>("http://localhost:37776", "api/Customers/PostAdd", Method.POST, customer);
            return RedirectToAction("GetAllCustomers");
        }
        [HttpGet]
        public ActionResult EditCustomer(string Id)
        {
            Customer customer = HttpHelperMethods.GetWithId<Customer>("http://localhost:37776", "api/Customers/GetWithId", Method.GET, Id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            HttpHelperMethods.Edit<Customer>("http://localhost:37776", "api/Customers/Update", Method.POST, customer);
            return RedirectToAction("GetAllCustomers");
        }

        public ActionResult DeleteCustomer(string Id)
        {
            HttpHelperMethods.Delete<Customer>("http://localhost:37776", "api/Customers/Delete", Method.DELETE, Id);
            return RedirectToAction("GetAllCustomers");
        }


    }
}