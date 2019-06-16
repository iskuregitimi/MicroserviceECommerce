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
            return View();
        }

        public ActionResult ListEmployees()
        {
            List<EmployeeModel> emps = new List<EmployeeModel>();
            emps = HTTPHelper.SendRequest<List<EmployeeModel>>("http://localhost:37786", "Employee/GetEmployees", Method.GET);
            return View(emps);
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }

        public ActionResult AddEmployee(EmployeeModel model)
        {
            HTTPHelper.SendRequestModel<EmployeeModel>("http://localhost:37786", "Employee/AddEmployee", model, Method.POST);
            return RedirectToAction("ListEmployees");
        }

        public ActionResult UpdateEmployee(string id)
        {
            var employee = HTTPHelper.SendRequestParam<EmployeeModel>("http://localhost:37786", "Employee/GetEmployee", id, Method.GET);
            return View(employee);
        }

        public ActionResult SaveUpdatedEmployee(EmployeeModel model)
        {
            HTTPHelper.SendRequestModel<EmployeeModel>("http://localhost:37786", "Employee/UpdateEmployee", model, Method.POST);
            return RedirectToAction("ListEmployees");
        }

        public ActionResult DeleteEmployee(string id)
        {
            HTTPHelper.DeleteMethod("http://localhost:37786/", "Employee/DeleteEmployee", Method.DELETE, id);
            return RedirectToAction("ListEmployees");
        }
    }
}