using MicroserviceECommerce.MVCUI.Entities;
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
            return View();
        }

        public ActionResult GetEmployees()
        {
            List<Employees> employees = new List<Employees>();
            employees = HttpHelper.GetList<List<Employees>>("http://localhost:37776", "Employee/GetEmployees", Method.GET);
            return View(employees);
        }
    }
}