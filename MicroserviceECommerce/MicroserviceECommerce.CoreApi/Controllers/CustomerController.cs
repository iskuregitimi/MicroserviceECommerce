using MicroserviceECommerce.CoreApi.DataBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceECommerce.CoreApi.Controllers
{
    public class CustomerController:ControllerBase
    {
        NorthwindContext _northwindContext;
        public CustomerController (NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        [HttpGet]
        public List<Customer> List()
        {
            var result = _northwindContext.Customers.ToList();
            return result;
        }
    }
}
