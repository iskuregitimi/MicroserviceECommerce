using MicroserviceECommerce.MVCUI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomers()
        {
            List<Customers> customers = new List<Customers>();
            customers = CustomerHelper.GetList<List<Customers>>("http://localhost:37776", "Customer/GetCustomers", Method.GET);
            return View(customers);
        }
        public ActionResult GetCustomer()
        {

            Customers customers = CustomerHelper.GetList<Customers>("http://localhost:37776", "Customer/FindCustomer", Method.GET);
            return View(customers);
        }

        public ActionResult EditCustomer(string id)
        {

            Customers customer = CustomerHelper.GetDetail<Customers>("http://localhost:37776/", "Customer/FindCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(Customers customer)
        {
            CustomerHelper.Update<Customers>("http://localhost:37776/", "Customer/UpdateCustomer", Method.POST, customer);
            return RedirectToAction("GetCustomers");
        }

        public ActionResult DeleteCustomer(string id)
        {
            CustomerHelper.Delete<Customers>("http://localhost:37776/", "Customer/DeleteCustomer", Method.GET, id);
            return RedirectToAction("GetCustomers");
        }


    }
}