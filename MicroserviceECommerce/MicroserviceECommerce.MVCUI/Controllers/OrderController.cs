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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListOrders()
        {
            List<Order> orders = HTTPHelper.SendRequest<List<Order>>("http://localhost:37796/", "Order/GetAllOrders", Method.GET);
            return View(orders);
        }

        public ActionResult GetCustomerOrder(string id)
        {
            List<Order> orders = HTTPHelper.SendRequestParam<List<Order>>("http://localhost:37796/", "Order/GetCustomerOrder", id, Method.GET );
            return View(orders);
        }

        public ActionResult GetOrderDetail(int id)
        {
            List<OrderDetail> orders = HTTPHelper.SendRequestParam<List<OrderDetail>>("http://localhost:37796/", "OrderDetail/GetOrderDetails", id, Method.GET);
            return View(orders);
        }
    }
}