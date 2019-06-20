//using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI.Models;
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
            List<CustomerModel> customerList = new List<CustomerModel>();
            customerList = HttpHelper.SendRequest<List<CustomerModel>>("http://localhost:37776/", "api/Customer/GetCustomers", Method.GET);
            return View(customerList);
        }

        public ActionResult GetCustomer(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HttpHelper.GetDetail<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", Method.GET, id);
            return View(customer);
        }


    }
}