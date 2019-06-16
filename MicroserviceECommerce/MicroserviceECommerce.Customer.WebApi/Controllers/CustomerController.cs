
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
        RepositoryPattern<Customers> repo = new RepositoryPattern<Customers>();

        [HttpGet]
        public List<Customers> GetCustomers()
        {
            List<Customers> customers = repo.List();
            return customers;
        }

        [HttpGet]
        public Customers FindCustomer(string id)
        {
            Customers customer = repo.Find(x=>x.CustomerID==id);
            return customer;
        }

        [HttpPost]
        public void UpdateCustomer(Customers customer)
        {
            repo.Update(customer);
        }

        [HttpPost]
        public void AddCustomer(Customers customer)
        {
            repo.Insert(customer);
        }
    }
}