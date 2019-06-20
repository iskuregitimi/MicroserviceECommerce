﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.CORE.UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {

            List<Customers> customerList = HTTPHelper.SendRequest<List<Customers>>("http://localhost:37776", "api/Customer/GetCustomers", RestSharp.Method.GET);
            return View(customerList);
        }
    }
}