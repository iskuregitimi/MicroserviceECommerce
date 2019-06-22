﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.CORE.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employees> employeeList = HTTPHelper.GetData<List<Employees>>("http://localhost:37786/", "api/Employee/GetEmployees", RestSharp.Method.GET);
            return View(employeeList);
        }
    }
}