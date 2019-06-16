using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class OrderDetailController : ApiController
    {
        Repository<Order_Details> repo = new Repository<Order_Details>();

        public List<Order_Details> GetOrderDetails(int Id)
        {
            List<Order_Details> orderdetails = repo.List(x => x.OrderID == Id);
            return orderdetails;
        }
    }
}