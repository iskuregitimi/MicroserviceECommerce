using MicroserviceECommerce.MVCUI.HttpHelperMethods;
using MicroserviceECommerce.MVCUI.Models;
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
            CustomerModel_ customer = HttpHelper.GetListMethod<CustomerModel_>("http://localhost:37776", "CustomerCRUD/GetCustomers", RestSharp.Method.GET);
            return View(customer);
        }
    }
}