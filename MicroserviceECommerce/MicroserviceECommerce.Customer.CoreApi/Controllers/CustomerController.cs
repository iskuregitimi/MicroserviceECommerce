using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Customer.CoreApi.Database;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceECommerce.Customer.CoreApi.Controllers
{
    public class CustomerController : Controller
    {
        public List<Customers> Index()
        {
            using (NortwindContext db = new NortwindContext())
            {
                List<Customers> models = db.Customers.Select(x => new Customers
                {
                    Address = x.Address,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    ContactName = x.ContactName,
                    ContactTitle = x.ContactTitle,
                    Country = x.Country,
                    CustomerID = x.CustomerID,
                    Fax = x.Fax,
                    Password = x.Password,
                    Phone = x.Phone,
                    PostalCode = x.PostalCode,
                    Region = x.Region

                }).ToList();
                return models;
            }
           
        }
    }
}