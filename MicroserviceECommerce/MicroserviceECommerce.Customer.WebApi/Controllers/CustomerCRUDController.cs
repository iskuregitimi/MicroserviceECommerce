using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomerCRUDController:ApiController
    {
        DataContext db = new DataContext();
        //list all customers
        [HttpGet]
        public List<CustomerModel> GetCustomers()
        {
            var customers = db.Customers.Select(y => new CustomerModel
            {
                CustomerID = y.CustomerID,
                CompanyName = y.CompanyName,
                ContactName = y.ContactName,
                ContactTitle = y.ContactTitle,
                Address = y.Address,
                City = y.City,
                Region = y.Region,
                PostalCode = y.PostalCode,
                Country = y.Country,
                Phone = y.Phone,
                Fax = y.Fax,
                Password = y.Password
            }).ToList();
            return customers;
        }
        //add customer
        public void AddCustomer(Customers _customer)
        {
            db.Customers.Add(_customer);
            db.SaveChanges();
        }
        //update customer
        public void UpdateCustomer(Customers _customer)
        {
            Customers customer = db.Customers.FirstOrDefault(x => x.CustomerID == _customer.CustomerID);
            customer.CustomerID = _customer.CustomerID;
            customer.CompanyName = _customer.CompanyName;
            customer.ContactName = _customer.ContactName;
            customer.ContactName = _customer.ContactTitle;
            customer.Address = _customer.Address;
            customer.City = _customer.City;
            customer.Region = _customer.Region;
            customer.PostalCode = _customer.PostalCode;
            customer.Country = _customer.Country;
            customer.Phone = _customer.Phone;
            customer.Fax = _customer.Fax;
            customer.Password = _customer.Password;
            db.SaveChanges();
        }
        //delete customer
        public void DeleteCustomer(string id)
        {
            Customers customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
    }
}