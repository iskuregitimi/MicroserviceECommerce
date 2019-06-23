using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Core.Customer.WebApi.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Core.Customer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        DataContext _dataContext;
        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public List<Customers> List()
        {
            var result = _dataContext.Customers.ToList();
            return result;
        }


    }
}
