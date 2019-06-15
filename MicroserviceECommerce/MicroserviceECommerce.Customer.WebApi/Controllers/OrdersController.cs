using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class OrdersController : ApiController
    {
        DataContext db = new DataContext();


        public List<OrdersModel> GetCustomerOrders(string id)
        {
            return db.Orders.Where(x => x.CustomerID == id).Select(x => new OrdersModel
            {
                OrderID = x.OrderID,
                CustomerID = x.CustomerID,
                EmployeeID = x.EmployeeID,
                OrderDate = x.OrderDate,
                RequiredDate = x.RequiredDate,
                ShippedDate = x.ShippedDate,
                ShipVia = x.ShipVia,
                Freight = x.Freight,
                ShipName = x.ShipName,
                ShipAddress = x.ShipAddress,
                ShipCity = x.ShipCity,
                ShipRegion = x.ShipRegion,
                ShipPostalCode = x.ShipPostalCode,
                ShipCountry = x.ShipCountry,
                Status = x.Status
            }).ToList();
        }
        public int AddOrder(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.OrderID;
        }
        public void PutOrder(OrderAddModel oam)
        {
            OrderDetailsController odc = new OrderDetailsController();
            Orders order = new Orders
            {
                OrderID=oam.OrderID,
                CustomerID = oam.CustomerID,
                EmployeeID = oam.EmployeeID,
                OrderDate = oam.OrderDate,
                RequiredDate = oam.RequiredDate,
                ShippedDate = oam.ShippedDate,
                ShipVia = oam.ShipVia,
                Freight = oam.Freight,
                ShipName = oam.ShipName,
                ShipAddress = oam.ShipAddress,
                ShipCity = oam.ShipCity,
                ShipRegion = oam.ShipRegion,
                ShipPostalCode = oam.ShipPostalCode,
                ShipCountry = oam.ShipCountry,
                Status = oam.Status
            };
            int id = AddOrder(order);
            Order_Details od = new Order_Details
            {
                OrderID = id,
                ProductID = oam.ProductID,
                UnitPrice = oam.UnitPrice,
                Quantity = oam.Quantity,
                Discount = oam.Discount
            };
            AddOrder(order);
            odc.PutOrderDetails(od);
        }
    }
}
