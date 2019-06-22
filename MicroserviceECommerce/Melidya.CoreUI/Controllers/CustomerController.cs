using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Melidya.CoreUI.Controllers
{
    public class CustomerController:Controller
    {
        public IActionResult Index()
        {
            List<Customers> customers = new List<Customers>();
            customers = CustomerHelper.GetList<List<Customers>>("http://localhost:37776", "Customer/GetCustomers", Method.GET);
            return View(customers);
        }


    }
}
