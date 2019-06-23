﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.CORE.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.CORE.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<CustomerModel> customerList = HTTPHelper.GetData<List<CustomerModel>>("http://localhost:37776", "api/Customer/GetCustomers", RestSharp.Method.GET);
            return View(customerList);
        }

        public IActionResult List()
        {
            List<CustomerModel> customerList = HTTPHelper.GetData<List<CustomerModel>>("http://localhost:62419", "api/Customer/List", RestSharp.Method.GET);
            return View(customerList);
        }

        public IActionResult customerDetail(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HTTPHelper.SendIdGetData<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", RestSharp.Method.GET, id);
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
            HTTPHelper.SendData("http://localhost:37776", "api/Customer/AddCustomer", RestSharp.Method.POST, customer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteCustomer(string id)
        {
            HTTPHelper.SendId("http://localhost:37776", "api/Customer/DeleteCustomer",RestSharp.Method.DELETE, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCustomer(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HTTPHelper.SendIdGetData<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", RestSharp.Method.GET, id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(CustomerModel customer)
        {
            HTTPHelper.SendData("http://localhost:37776", "api/Customer/EditCustomer", RestSharp.Method.POST, customer);
            return RedirectToAction("Index");
        }




    }
}