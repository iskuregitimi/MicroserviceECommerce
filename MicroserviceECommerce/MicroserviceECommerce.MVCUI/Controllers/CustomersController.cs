using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
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
        public ActionResult GetCustomers()
        {
            var customers = HTTPHelpers.GetListMethod<List<CustomersModel>>("http://localhost:37786/", "Customers/GetCustomers", RestSharp.Method.GET);
            return View(customers);
        }
        public ActionResult PutCustomer(CustomersModel customer)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Customers/PutCustomer", RestSharp.Method.PUT, customer);
            return RedirectToAction("GetCustomers");
        }
        public ActionResult GetCustomer(string id)
        {
            var customer = HTTPHelpers.GetMethod<CustomersModel>("http://localhost:37776/", "Customers/GetCustomerDetail", RestSharp.Method.GET, id);
            return View(customer);
        }
        public ActionResult UpdatePerson(CustomersModel customer)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Customers/PostCustomer", RestSharp.Method.POST, customer);
            return RedirectToAction("GetCustomer");
        }
        public ActionResult DeleteCustomer(string id)
        {
            HTTPHelpers.DeleteMethod("http://localhost:37786/", "Customers/DeleteCustomer", RestSharp.Method.DELETE, id);
            return RedirectToAction("GetCustomers");
        }
        public ActionResult CustomerAdd()
        {
            return View(new CustomersModel());
        }
    }
}