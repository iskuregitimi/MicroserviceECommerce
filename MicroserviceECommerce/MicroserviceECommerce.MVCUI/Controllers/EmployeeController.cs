using RestSharp;
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
            List<Employee> employee = new List<Employee>();
            employee = HTTPHELPER.SendRequestList<List<Employee>>("http://localhost:37786", "Employee/GetEmployees", Method.GET);
            return View(employee);

        }
    }
}