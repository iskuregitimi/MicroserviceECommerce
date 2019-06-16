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
        public List<Orders> GetOrders()
        {
            List<Orders> orders = repo.List();
            return orders;
        }

        [HttpGet]
        public List<Orders> CustomerGetOrder(string Id)
        {
            List<Orders> orders = repo.List(x=>x.CustomerID==Id);
            return orders;
        }
    }
}