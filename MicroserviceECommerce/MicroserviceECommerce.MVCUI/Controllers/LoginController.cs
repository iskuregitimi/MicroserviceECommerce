using MicroserviceECommerce.MVCUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(LoginModel model)
        {
           CustomerModell customerModell=HttpHelper.SendRequest<CustomerModell>("http://localhost:37776/", "Customer/CustomersLogin", Method.POST);
            if (customerModell.Password==model.Password)
            {
                return RedirectToAction("Index", "Customer");

            }
            return View();

        }

    }
}