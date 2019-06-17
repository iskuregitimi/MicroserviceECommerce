using MicroserviceECommerce.MVCUI.HttpHelperMethods;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomerLoginController : Controller
    {
        // GET: CustomerLogin
        public ActionResult CustomerLogin()
        {
            return View();
        }

        // GET: Customer
        [HttpPost]
        public ActionResult CustomerLogin(string customerID, string password)
        {
            var customer = HttpHelper.GetMethod<CustomerModel_>("http://localhost:37776", "Login/GetCustomer", RestSharp.Method.GET, customerID, password);
            if (customer.Password == password)
            {
                Session["Login"] = customer;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LoginHata");
        }
        public ActionResult LoginHata()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("Login");
            return RedirectToAction("CustomerLogin");
        }
    }
}