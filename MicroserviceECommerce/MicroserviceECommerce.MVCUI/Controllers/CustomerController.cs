using MicroserviceECommerce.Customer.WepApi;
using MicroserviceECommerce.Entities;
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
        // GET: Customer

        public ActionResult ListCustomer()
        {
            List<customerDTO> customer = new List<customerDTO>();

            customer = HTTPHELPER.SendRequestList<List<customerDTO>>("http://localhost:52373", "Customer/ListCustomers", Method.GET);
            return View(customer);
        }
        
        public ActionResult CreateCustomer()
        {
            return View();

        }
     [HttpPost]
        public ActionResult CreateCustomer(customerDTO customer)
        {
            HTTPHELPER.SendRequestCreate<customerDTO>("http://localhost:52373", "Customer/AddCustomer", customer, Method.POST);
            return RedirectToAction("ListCustomer");


        }
      [HttpGet]
        public ActionResult UpdateCustomer(string id)
        {
            var tk = HTTPHELPER.SendRequestParam<customerDTO>("http://localhost:52373", "Customer/GetCustomer",id, Method.GET);


            return View(tk);
            

        }

        [HttpPost]
        
        public ActionResult UpdateCustomer(customerDTO model)
        {
            HTTPHELPER.SendRequestCreate<customerDTO>("http://localhost:52373", "Customer/UpdateCustomer", model, Method.POST);
            return RedirectToAction("ListCustomer");

        }



    }
}