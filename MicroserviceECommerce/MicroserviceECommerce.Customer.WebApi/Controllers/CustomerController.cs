using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        DataContext db = new DataContext();

        [HttpGet]
        public List<Customers> GetCustomers()
        {
            List<Customers> customers = db.Customers.ToList();
            return customers;
        }

    }
}