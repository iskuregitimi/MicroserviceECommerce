
using MicroserviceECommerce.Customer.WebApi.Models;
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
        RepositoryPattern<Orders> repo1 = new RepositoryPattern<Orders>();
        RepositoryPattern<Order_Details> repo2 = new RepositoryPattern<Order_Details>();
        [HttpGet]
        public List<CustomerModel> GetCustomers()
        {
            using (DataContext db=new DataContext())
            {
                return db.Customers.Select(x => new CustomerModel
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
                    PostalCode=x.PostalCode,
                    Region=x.Region
                  
                }).ToList();
            }
        }

        [HttpGet]
        public CustomerModel FindCustomer(string id)
        {
            using (DataContext db = new DataContext())
            {
                return db.Customers.Where(x=>x.CustomerID==id).Select(x => new CustomerModel
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

                }).FirstOrDefault();
            }
        }

        [HttpPost]
        public void UpdateCustomer(Customers customer)
        {         
              Customers cust= repo.Find(x=>x.CustomerID==customer.CustomerID);
                cust.ContactName = customer.ContactName;
                cust.CompanyName = customer.CompanyName;
                cust.Address = customer.Address;
                cust.City = customer.City;
                cust.ContactTitle = customer.ContactTitle;
                cust.Country = customer.Country;
                cust.Password = customer.Password;
                cust.Phone = customer.Phone;
                cust.PostalCode = customer.PostalCode;
                cust.Region = customer.Region;
                repo.Update(cust);           
        }
        
        [HttpPost]
        public void AddCustomer(Customers customer)
        {
            repo.Insert(customer);
        }


        [HttpGet]
        public void DeleteCustomer(string Id)
        {
            using (DataContext db=new DataContext())
            {
                Customers cust = repo.Find(x => x.CustomerID == Id);
                List<Orders> customerorder = repo1.List(x => x.CustomerID == cust.CustomerID);
                //List<Order_Details> order_Details = repo2.List(x => x.OrderID == customerorder.OrderID);

                foreach (var item in customerorder)
                {
                    db.Orders.Remove(item);
                }
                db.Customers.Remove(cust);
                db.SaveChanges();
            }
            
        }
    }
}