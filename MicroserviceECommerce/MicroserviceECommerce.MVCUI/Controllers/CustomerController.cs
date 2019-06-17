

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
            List<Customers> customer = new List<Customers>();

            customer = HTTPHELPER.SendRequestList<List<Customers>>("http://localhost:52373", "Customer/ListCustomers", Method.GET);
            return View(customer);
        }
        
        public ActionResult CreateCustomer()
        {
            return View();

        }
     [HttpPost]
        public ActionResult CreateCustomer(Customers customer)
        {
            HTTPHELPER.SendRequestCreate<Customers>("http://localhost:52373", "Customer/AddCustomer", customer, Method.POST);
            return RedirectToAction("ListCustomer");


        }
      [HttpGet]
        public ActionResult UpdateCustomer(string id)
        {
            var tk = HTTPHELPER.SendRequestParam<Customers>("http://localhost:52373", "Customer/GetCustomerclass", id, Method.GET);


            return View(tk);
            

        }

        [HttpPost]
        
        public ActionResult UpdateCustomer(Customers model)
        {
            HTTPHELPER.SendRequestCreate<Customers>("http://localhost:52373", "Customer/UpdateCustomer", model, Method.POST);
            return RedirectToAction("ListCustomer");

        }
        //Customer e göre order listele
        [HttpGet]
        public ActionResult Details(string id)
        {
            Customers k = new Customers();
            List<Orders> o = new  List<Orders>();
            //k = HTTPHELPER.SendRequestParam<Customers>("http://localhost:37796", "CustomerEcommerce/GetCustomer", id, Method.GET);
            o = HTTPHELPER.SendRequestParam<List<Orders>>("http://localhost:37796", "CustomerEcommerce/Listorders", id, Method.GET);
          
            return View(o);
         
        }
        //Customer sil
      
        public ActionResult Delete(string id)
        {
            HTTPHELPER.SendRequestParam<Customers>("http://localhost:52373", "Customer/DeleteCustomer", id, Method.POST);
            return RedirectToAction("ListCustomer");
        }

        public ActionResult Detaylar(int id)
        {
            List<orderdetailsmodel> o = new List<orderdetailsmodel>();
            o = HTTPHELPER.SendRequestParamdetail<List<orderdetailsmodel>>("http://localhost:37796", "CustomerEcommerce/OrderDetailList", id, Method.GET);
            return View(o);

        }
    }
}