using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class OrderController:ApiController
    {
        Repository<Orders> order_repo = new Repository<Orders>();
        
        public List<Orders> GetCustomersOrder(string id)
        {
            List<Orders> orders = order_repo.List(x => x.CustomerID == id);

            return orders;
        } 

    }
}