using MicroserviceECommerce.ECommerce.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class OrderDetailController:ApiController
    {
        RepositoryPattern<Order_Details> repo = new RepositoryPattern<Order_Details>();
        public List<OrderDetailModel> GetOrderDetails(int Id)
        {
            using (DataContext db = new DataContext())
            {
                List<OrderDetailModel> orderDetailModels = db.Order_Details.Where(x => x.OrderID == Id).Select(a => new OrderDetailModel
                {
                    OrderID=a.OrderID,
                    Discount=a.Discount,
                    ShipName=a.Orders.ShipName,
                    ProductID=a.ProductID,
                    ProductName=a.Products.ProductName,
                    Quantity=a.Quantity,
                    UnitPrice=a.UnitPrice
                }).ToList();
                return orderDetailModels;
            }

           
           
        }
    }
}