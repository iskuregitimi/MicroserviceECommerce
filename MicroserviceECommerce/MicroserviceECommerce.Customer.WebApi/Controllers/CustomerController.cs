using MicroserviceECommerce.Customer.WebApi.Models;
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
        public List<CustomerModel> GetCustomers()
        {
            List<Customers> customerList = db.Customers.ToList();
            List<CustomerModel> customerModelList = new List<CustomerModel>();

            foreach (Customers item in customerList)
            {
                CustomerModel model = new CustomerModel()
                {
                    CustomerID = item.CustomerID,
                    Address =item.Address,
                    City=item.City,
                    CompanyName=item.CompanyName,
                    ContactName=item.ContactName,
                    ContactTitle=item.ContactTitle,
                    Country=item.Country,
                    Fax=item.Fax,
                    Password=item.Password,
                    Phone=item.Phone,
                    PostalCode=item.PostalCode,
                    Region=item.Region
                };
                customerModelList.Add(model);
            }
            return customerModelList;
        }

        [HttpGet]
        public CustomerModel GetCustomer(string id)
        {
            Customers customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);

            CustomerModel model = new CustomerModel()
            {
                CustomerID = customer.CustomerID,
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                Fax = customer.Fax,
                Password = customer.Password,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };

            return model;
        }

        [HttpPost]
        public void InsertCustomer(CustomerModel customer)
        {
            Customers newCustomer = new Customers()
            {
                CustomerID = customer.CustomerID,
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Country = customer.Country,
                Fax = customer.Fax,
                Password = customer.Password,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };

            db.Customers.Add(newCustomer);
            db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(string id)
        {
            Customers customer = db.Customers.FirstOrDefault(x => x.CustomerID == id);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

    }
}