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
            customers = HttpHelper.GetList<List<Customers>>("http://localhost:37776", "Customer/GetCustomers", Method.GET);
            return View(customers);
        }

       
    }
}