using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class LoginController:ApiController
    {
        DataContext db = new DataContext();

        //login
        public CustomerModel GetCustomer(string id, string password)
        {
            CustomerModel customer = db.Customers.Where(x => x.CustomerID == id && x.Password == password).Select(y => new CustomerModel
            {
                CustomerID=y.CustomerID,
                CompanyName=y.CompanyName,
                ContactName=y.ContactName,
                ContactTitle=y.ContactTitle,
                Address=y.Address,
                City=y.City,
                Region=y.Region,
                PostalCode=y.PostalCode,
                Country=y.Country,
                Phone=y.Phone,
                Fax=y.Fax,
                Password=y.Password
            }).FirstOrDefault();
            return customer;
        }
    }
}