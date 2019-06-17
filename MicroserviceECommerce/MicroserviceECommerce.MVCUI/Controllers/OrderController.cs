using MicroserviceECommerce.MVCUI.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomerOrder(string Id)
        {
            List<Orders> orders = HttpHelper.HttpHelper.GetList<List<Orders>>("http://localhost:37796/", "Order/CustomerGetOrder", Method.GET, Id);
            return View(orders);
        }

        public ActionResult GetOrderDetail(int Id)
        {
            List<OrderDetails> orders =HttpHelper.HttpHelper.GetList<List<OrderDetails>>("http://localhost:37796/", "OrderDetail/GetOrderDetails", Method.GET, Id);
            return View(orders);
        }
    }
}