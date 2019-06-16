using MicroserviceECommerce.MVCUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            customers = HTTPHelper.SendRequest<List<CustomerModel>>("http://localhost:37776", "Customer/GetCustomers", Method.GET);
            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        public ActionResult AddCustomer(CustomerModel model)
        {
            HTTPHelper.SendRequestModel<CustomerModel>("http://localhost:37776", "Customer/AddCustomer", model, Method.POST);
            return RedirectToAction("ListCustomers");
        }

        public ActionResult UpdateCustomer(string id)
        {
            var customer = HTTPHelper.SendRequestParam<CustomerModel>("http://localhost:37776", "Customer/GetCustomer", id, Method.GET);
            return View(customer);
        }

        public ActionResult SaveUpdatedCustomer(CustomerModel model)
        {
            HTTPHelper.SendRequestModel<CustomerModel>("http://localhost:37776", "Customer/UpdateCustomer", model, Method.POST);
            return RedirectToAction("ListCustomers");
        }

        public ActionResult DeleteCustomer(string id)
        {
            HTTPHelper.DeleteMethod("http://localhost:37776/", "Customer/DeleteCustomer", Method.DELETE, id);
            return RedirectToAction("ListCustomers");
        }
    }
}