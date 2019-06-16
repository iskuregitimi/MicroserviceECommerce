using MicroserviceECommerce.Entities;

using MicroserviceECommerce.MVCUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            List<CustomerModell> customerModells = new List<CustomerModell>();
            customerModells = HttpHelper.SendRequest<List<CustomerModell>>("http://localhost:37776/","Customer/GetCustomers", Method.GET);
            return View(customerModells);
        }


        public ActionResult CustomersDetail(string id)
        {CustomerModell customerModell = HttpHelper.GetDetail<CustomerModell>("http://localhost:37776/", id, "Customer/CustomerDetail", Method.GET);

           
            return View(customerModell);
        }

        public  ActionResult InsertCustomers()
        {
            return View();
        }

        public ActionResult UpdateCustomer(string id)
        {
            CustomerModell customerModell = HttpHelper.GetDetail<CustomerModell>("http://localhost:37776/", id, "Customer/CustomerDetail", Method.GET);


            return View(customerModell);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerModell customerModell)
        {
            HttpHelper.AddRequestParam<Customers>("http://localhost:37776/", "Customer/UpdateCustomers", customerModell, Method.POST);
            return View();

        }
        [HttpPost]
        public ActionResult InsertCustomers(Customers customers)
        {
        
             HttpHelper.AddRequestParam<Customers>("http://localhost:37776/", "Customer/InsertCustomer", customers, Method.POST);
            return View();
        }

        public ActionResult DeleteCustomer(string id)
        {
            HttpHelper.GetDetail<Customers>("http://localhost:37776/", "Customer/DeleteCustomer", id, Method.POST);
            return RedirectToAction("Index");
        }

    }
}