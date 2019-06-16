using MicroserviceECommerce.MVCUI.HttpHelperMethods;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(string id, string password)
        {
            var employee = HttpHelper.GetMethod<EmployeeModel_>("http://localhost:37786", "EmployeeLogin/GetEmployee", RestSharp.Method.GET, id, password);
            if (employee.Password == password)
            {
                Session["EmployeeLogin"] = employee;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LoginHata","Customer");
        }

        public ActionResult Logout()
        {
            Session.Remove("EmployeeLogin");
            return RedirectToAction("EmployeeLogin");
        }
    }
}