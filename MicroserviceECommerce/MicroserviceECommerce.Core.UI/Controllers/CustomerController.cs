using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Core.UI.Models;
using MicroserviceECommerce.MVCUI;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MicroserviceECommerce.Core.UI.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            customerList = HttpHelper.SendRequest<List<CustomerModel>>("http://localhost:37776/", "api/Customer/GetCustomers", Method.GET);
            return View(customerList);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HttpHelper.GetDetail<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult InsertCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertCustomer(CustomerModel customer)
        {
            HttpHelper.InsertCustomer<CustomerModel>("http://localhost:37776", "api/Customer/InsertCustomer", Method.POST, customer);


            return RedirectToAction("Index");
        }
    }
}