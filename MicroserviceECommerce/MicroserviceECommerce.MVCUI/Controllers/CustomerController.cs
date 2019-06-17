using MicroserviceECommerce.Entities;
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
           List <CustomerModel_> customermodel = HttpHelper.GetListMethod<List<CustomerModel_>>("http://localhost:37776", "CustomerCRUD/GetCustomers", RestSharp.Method.GET);
            return View(customermodel);

        }

        [HttpGet]
        public ActionResult CustomerDetails(string id)
        {
            CustomerModel_ customermodel = HttpHelper.GetMethod<CustomerModel_>("http://localhost:37776", "CustomerCRUD/CustomerDetail", RestSharp.Method.GET,id);
            return View(customermodel);

        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customers customers)
        {
            HttpHelper.PostMethod("http://localhost:37776", "CustomerCrud/AddCustomer", RestSharp.Method.POST, customers);
            return RedirectToAction("CustomerList");
        }
        public ActionResult DeleteCustomer(string id)
        {
            HttpHelper.DeleteMethod("http://localhost:37776", "CustomerCrud/DeleteCustomer", RestSharp.Method.DELETE, id);
            return RedirectToAction("CustomerList");
        }
    }
}