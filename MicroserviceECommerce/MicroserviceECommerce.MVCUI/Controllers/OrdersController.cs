using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
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
        public ActionResult GetOrders()
        {
            var orders = HTTPHelpers.GetListMethod<List<OrdersModel>>("http://localhost:37786/", "Orders/GetOrders", RestSharp.Method.GET);
            return View(orders);
        }
        public ActionResult PutOrders(OrderAddModel orders)
        {
            HTTPHelpers.PostMethod("http://localhost:37776/", "Orders/PutOrder", RestSharp.Method.PUT, orders);
            return RedirectToAction("GetOrders");
        }
        public ActionResult GetCutomerOrder(string id)
        {
            var order = HTTPHelpers.GetMethod<List<OrdersModel>>("http://localhost:37776/", "Orders/GetCustomerOrders", RestSharp.Method.GET, id);
            return View(order);
        }
        public ActionResult GetOrder(int id)
        {
            var order = HTTPHelpers.GetMethod<OrdersModel>("http://localhost:37776/", "Orders/GetOrder", RestSharp.Method.GET, id);
            return View(order);
        }
        public ActionResult PostOrder(OrdersModel order)
        {
            HTTPHelpers.PostMethod("http://localhost:37786/", "Orders/PostOrder", RestSharp.Method.POST, order);
            return RedirectToRoute(new { controller = "Orders", action = "GetOrder", id = order.OrderID });
        }
        public ActionResult DeleteOrder(int id)
        {
            HTTPHelpers.DeleteMethod("http://localhost:37786/", "Orders/DeleteOrder", RestSharp.Method.DELETE, id);
            return RedirectToAction("GetOrders");
        }
        public ActionResult OrderAdd()
        {
            return View(new OrderAddModel());
        }
        public ActionResult UpdateOrder(int id)
        {
            var order = HTTPHelpers.GetMethod<OrdersModel>("http://localhost:37776/", "Orders/GetOrder", RestSharp.Method.GET, id);
            return View(order);
        }
    }
}