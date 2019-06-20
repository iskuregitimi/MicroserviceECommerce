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
        public IActionResult Index()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            customerList = HttpHelper.SendRequest<List<CustomerModel>>("http://localhost:37776/", "api/Customer/GetCustomers", Method.GET);
            return View(customerList);
        }
    }
}