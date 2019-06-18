using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> employeeList = HTTPHelper.SendRequest<List<Employees>>("http://localhost:37786/", "api/Employee/GetEmployees", RestSharp.Method.GET);
            return View(employeeList);
        }
    }
}