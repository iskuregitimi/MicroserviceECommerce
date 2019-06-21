using MicroserviceECommerce.Entities;
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

            List<Customers> customerList = new List<Customers>();
            customerList = HTTPHelper.SendRequest<List<Customers>>("http://localhost:37776", "api/Customer/GetCustomers", RestSharp.Method.GET);
            return View(customerList);
        }
        public ActionResult customerDetail(string id)
        {
            Customers customer = new Customers();
            customer = HTTPHelper.GetDetail<Customers>("http://localhost:37776", "api/Customer/GetCustomers", RestSharp.Method.GET, id);
            return View(customer);


        }
    }
}