using MicroserviceECommerce.MVCUI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult CustomersOrder(string id)
        {
            List<OrderModel> orderModels = HttpHelper.GetDetail<List<OrderModel>>("http://localhost:37786/", "Order/GetCustomersOrder", id, Method.GET);

            return View(orderModels);
        }
    }
}