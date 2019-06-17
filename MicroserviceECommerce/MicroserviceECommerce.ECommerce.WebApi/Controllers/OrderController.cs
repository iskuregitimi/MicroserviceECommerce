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
        RepositoryPattern<Orders> repo = new RepositoryPattern<Orders>();
        [HttpGet]
        public List<OrderModel> GetOrders()
        {
            using (DataContext db=new DataContext())
            {
                return db.Orders.Select(x => new OrderModel
                {
                    CustomerID=x.CustomerID,
                    EmployeeID=x.EmployeeID,
                    Freight=x.Freight,
                    OrderDate=x.OrderDate,
                    OrderID=x.OrderID,
                    RequiredDate=x.RequiredDate,
                    ShipAddress=x.ShipAddress,
                    ShipCity=x.ShipCity,
                    ShipCountry=x.ShipCountry,
                    ShipName=x.ShipName,
                    ShippedDate=x.ShippedDate,
                    ShipPostalCode=x.ShipPostalCode,
                    ShipRegion=x.ShipRegion,
                    ShipVia=x.ShipVia,
                    Status=x.Status
                }).ToList();

            }
        }

        [HttpGet]
        public List<OrderModel> CustomerGetOrder(string Id)
        {
         
            using (DataContext db = new DataContext())
            {
                List<OrderModel> orderModels = db.Orders.Where(x=>x.CustomerID==Id).Select(x => new OrderModel
                {
                    CustomerID = x.CustomerID,
                    EmployeeID = x.EmployeeID,
                    Freight = x.Freight,
                    OrderDate = x.OrderDate,
                    OrderID = x.OrderID,
                    RequiredDate = x.RequiredDate,
                    ShipAddress = x.ShipAddress,
                    ShipCity = x.ShipCity,
                    ShipCountry = x.ShipCountry,
                    ShipName = x.ShipName,
                    ShippedDate = x.ShippedDate,
                    ShipPostalCode = x.ShipPostalCode,
                    ShipRegion = x.ShipRegion,
                    ShipVia = x.ShipVia,
                    Status = x.Status,
                    Customer=x.Customers.ContactName,
                    Employee=x.Employees.FirstName
                }).ToList();
                return orderModels;
            }
           
        }
    }
}