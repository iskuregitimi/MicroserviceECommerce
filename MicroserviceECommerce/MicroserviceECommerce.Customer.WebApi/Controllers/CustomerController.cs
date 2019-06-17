using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomerController:ApiController
    {
        DataContext dataContext = new DataContext();
        public List<Customers> GetCustomers()
        {
            List<Customers> customers= dataContext.Customers.ToList();

            return customers;
        }
    }
}