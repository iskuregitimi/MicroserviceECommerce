using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        Repository<Orders> repo = new Repository<Orders>();

        [HttpGet]
        public List<Orders> GetAllOrders()
        {
            List<Orders> orders = repo.List();
            return orders;
        }

        [HttpGet]
        public List<Orders> GetCustomerOrder(string Id)
        {
            List<Orders> orders = repo.List(x => x.CustomerID == Id);
            return orders;
        }

    }
}