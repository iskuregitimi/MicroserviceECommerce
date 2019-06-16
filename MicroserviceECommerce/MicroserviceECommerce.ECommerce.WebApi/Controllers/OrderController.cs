using MicroserviceECommerce.ECommerce.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class OrderController:ApiController
    {
        DataContext db = new DataContext();

        //Customer orders
        public List<OrderModel> GetOrders(string id)
        {
            List<OrderModel> customerOrders = db.Orders.Where(y=>y.CustomerID==id).Select(x => new OrderModel
            {
                OrderID=x.OrderID,
                CustomerID=x.CustomerID,
                EmployeeID=x.EmployeeID,
                OrderDate=x.OrderDate,
                RequiredDate=x.RequiredDate,
                ShippedDate=x.ShippedDate,
                ShipVia=x.ShipVia,
                Freight=x.Freight,
                ShipName=x.ShipName,
                ShipAddress=x.ShipAddress,
                ShipCity=x.ShipCity,
                ShipRegion=x.ShipRegion,
                ShipPostalCode=x.ShipPostalCode,
                ShipCountry=x.ShipCountry
            }).ToList();
            return customerOrders;
        }
    }
}