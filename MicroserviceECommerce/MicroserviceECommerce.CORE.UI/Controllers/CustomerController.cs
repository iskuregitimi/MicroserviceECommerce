using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.CORE.UI.Models;
//using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.CORE.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {

            List<CustomerModel> customerList = HTTPHelper.SendRequest<List<CustomerModel>>("http://localhost:37776", "api/Customer/GetCustomers", RestSharp.Method.GET);
            return View(customerList);
        }

        public IActionResult customerDetail(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HTTPHelper.GetDetail<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", RestSharp.Method.GET, id);
            return View(customer);

        }

        [HttpGet]
        public IActionResult AddCustomer()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel customer)
        {
            HTTPHelper.AddCustomer<CustomerModel>("http://localhost:37776", "api/Customer/AddCustomer", RestSharp.Method.POST, customer);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCustomer(string id)
        {
            HTTPHelper.DeleteCustomer("http://localhost:37776", "api/Customer/DeleteCustomer",RestSharp.Method.DELETE, id);

            return RedirectToAction("Index");
        }



    }
}