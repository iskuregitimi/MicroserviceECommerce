
using MicroserviceECommerce.MVCUI.Models;
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
            List<EmployeeModell> employees = HttpHelper.SendRequest<List<EmployeeModell>>("http://localhost:37786/", "Employee/GetEmployees", Method.GET);
         
            return View(employees);
        }

        public ActionResult InsertEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertEmployee(EmployeeModell model)
        {

            HttpHelper.AddRequestParam<EmployeeModell>("http://localhost:37786/", "Employee/InsertEmployee", model,Method.POST);
            return View();
        }

        public ActionResult UpdateEmployee()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UpdateEmployee(EmployeeModell employeeModell)
        {
            HttpHelper.AddRequestParam<EmployeeModell>("http://localhost:37786/", "Employee/UpdateEmployee", employeeModell, Method.POST);
            return View();
        }
    }
}