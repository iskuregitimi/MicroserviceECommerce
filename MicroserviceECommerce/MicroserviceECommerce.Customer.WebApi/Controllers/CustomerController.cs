using MicroserviceECommerce.Entities.EntityFramework;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MicroserviceECommerce.Customer.WebApi.Models;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        Repository<Customers> repo_Customer = new Repository<Customers>();
        Repository<CustomerModell> repo_CustomerModell = new Repository<CustomerModell>();
        [HttpGet]
        public List<CustomerModell> GetCustomers()
        {
            var customer = repo_Customer.List();
            List<CustomerModell> model = new List<CustomerModell>();
            foreach (var item in customer)
            {
                CustomerModell customerModel = new CustomerModell
                {
                    Address = item.Address,
                    City = item.City,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName,
                    ContactTitle = item.ContactTitle,
                    Country = item.Country,
                    CustomerID = item.CustomerID,
                    Fax = item.Fax,
                    Password = item.Password,
                    Phone = item.Phone,
                    PostalCode = item.PostalCode,
                    Region = item.Region
                };
                model.Add(customerModel);
            }
            return model;
        }



        [HttpGet]
        public CustomerModell CustomerDetail(string id)
        {
            Customers customers =repo_Customer.Find(x => x.CustomerID == id);

            CustomerModell modell = new CustomerModell
            {
                Address = customers.Address,
                City = customers.City,
                CompanyName = customers.CompanyName,
                ContactName = customers.ContactName,
                ContactTitle = customers.ContactTitle,
                Country = customers.Country,
                CustomerID = customers.CustomerID,
                Fax = customers.Fax,
                Password = customers.Password,
                Phone = customers.Phone,
                PostalCode = customers.PostalCode,
                Region = customers.Region
            };
            return modell;
            

        }

        [HttpPost]

        public void InsertCustomer(Customers customers)
        {

            Customers customer = new Customers();
            customer.ContactName = customers.ContactName;
            customer.CompanyName = customers.CompanyName;
            customer.Address = customers.Address;
            customer.CustomerID = customers.CustomerID;

            repo_Customer.Insert(customer);
          
        }

        [HttpPost]

        public void UpdateCustomers(CustomerModell modell)
        {
            Customers customers = new Customers
            {
                Address = modell.Address,
                City = modell.City,
                CompanyName = modell.CompanyName,
                ContactName = modell.ContactName,
                ContactTitle = modell.ContactTitle,
                Country = modell.Country,
                CustomerID = modell.CustomerID,
                Fax = modell.Fax,
                Password = modell.Password,
                Phone = modell.Phone,
                PostalCode = modell.PostalCode,
                Region = modell.Region
            };
            repo_Customer.Update(customers);
        }
        [HttpPost]

        public Customers DeleteCustomer(string id)
        {
            Customers customers = repo_Customer.Find(x => x.CustomerID == id);

            repo_Customer.Delete(customers);

            return customers;
        }
   

    }
}