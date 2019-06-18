using MicroserviceECommerce.Entities;
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
        public ActionResult Index()
        {
            List<Customers> customerList = new List<Customers>();
            customerList = HttpHelper.SendRequest<List<Customers>>("http://localhost:37776/", "api/Customer/GetCustomers", Method.GET);
            return View(customerList);
        }

        public ActionResult GetCustomer(string id)
        {
            Customers customer = new Customers();
            customer = HttpHelper.GetDetail<Customers>("http://localhost:37776","api/Customer/GetCustomer",Method.GET,id);
            return View(customer);
        }


    }
}