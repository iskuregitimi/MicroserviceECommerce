using MicroserviceECommerce.CoreUI.Entities;
using MicroserviceECommerce.CoreUI.HttpHelper;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceECommerce.CoreUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<Customers> customers = new List<Customers>();
            customers = CustomerHelper.GetList<List<Customers>>("http://localhost:50655", "Customer/Index", Method.GET);
            return View(customers);
        }

        public IActionResult CustomerDetail(string Id)
        {
            Customers cust = new Customers();
            cust = CustomerHelper.GetDetail<Customers>("http://localhost:37776","Customer/FindCustomer",Method.GET,Id);
            return View(cust);
        }

    }
}
