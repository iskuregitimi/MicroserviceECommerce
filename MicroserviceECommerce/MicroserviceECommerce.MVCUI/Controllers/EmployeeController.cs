using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.Models;
using MicroserviceECommerce.MVCUI.HttpHelpers;
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

        public ActionResult GetAll()
        {
            //buradaki employeeList boş geliyor.
            List<ModelEmployee> employeeList = HttpHelperMethods.GetAll<List<ModelEmployee>>("http://localhost:37786/", "api/Employee/GetAll", Method.GET);
            return View(employeeList);
        }

        public ActionResult GetWithId(int Id)
        {
            Employee employee = HttpHelperMethods.GetWithId<Employee>("http://localhost:37786/", "api/Employee/GetWithId", Method.GET, Id);
            return View(employee);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            HttpHelperMethods.Add<Employee>("http://localhost:37786/", "api/Employee/PostAdd", Method.POST, employee);
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            Employee employee = HttpHelperMethods.GetWithId<Employee>("http://localhost:37786/", "api/Employee/GetWithId", Method.GET, Id);
            return View(employee);
        }

        public ActionResult Edit(Employee employee)
        {
            HttpHelperMethods.Edit<Employee>("http://localhost:37786", "api/Employee/Update", Method.POST, employee);
            return RedirectToAction("GetAll");
        }

        public ActionResult Delete(int Id)
        {
            HttpHelperMethods.Delete<Employee>("http://localhost:37786", "api/Employee/Delete", Method.DELETE, Id);
            return RedirectToAction("GetAll");
        }
    }
}
