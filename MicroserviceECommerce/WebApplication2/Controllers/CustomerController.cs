using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DataBase;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        NorthwindContext _northwindContext;
        public CustomerController(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        [HttpGet]
        public List<Customer> List()
        {
            var result = _northwindContext.Customers.ToList();
            List<Customer> DataCustomersList=_northwindContext.Customers.ToList();
            List<Customer> Customers = new List<Customer>();
            foreach (var item in DataCustomersList)
            {
                Customer customer = new Customer
                {
                    CustomerID=item.CustomerID,
                    Address = item.Address,
                    City = item.City,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName,
                    ContactTitle = item.ContactTitle,
                    Country = item.Country,
                    Fax = item.Fax,
                    Password = item.Password,
                    Phone = item.Phone,
                    PostalCode = item.PostalCode,
                    Region = item.Region
                };
                Customers.Add(customer);
            }

            return result;
        }
    }
}
