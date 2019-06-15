using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.Customer.WepApi
{
    public class CustomrBLL
    {
        static DataContext db = new DataContext();

        public List<customerDTO> ListCustomers()
        { 
         
            List<customerDTO> customers = db.Customers.Select(x => new customerDTO()
            {
                Address = x.Address,
                City = x.City,
                CompanyName = x.CompanyName,
                CustomerID = x.CustomerID,
                Password = x.Password,
                Phone = x.Phone,
                ContactName = x.ContactName,
                Country = x.Country,
                ContactTitle = x.ContactTitle,
            }).ToList();
            
            return customers;
        }
        
        public void CreateCustomer(Customers customers)
        {
            db.Customers.Add(customers);
            db.SaveChanges();
        }

        //CustomerId sine göre bana bir customer getir.
        public Customers GetoneCustomer(string id)
        {
            var customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            return customer;
        }

        public void UpdateCustomer(Customers cust)
        {
            db.SaveChanges();
        }

    }
}