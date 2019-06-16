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
		[HttpGet]
        public ActionResult CustomerList()
        {
			List<Customers> customers = new List<Customers>();
			customers = HttpHelpers.SendRequest<List<Customers>>("http://localhost:37776", "api/Customer/CustomersList", Method.GET) ;
			return View(customers);
        }
    }
}