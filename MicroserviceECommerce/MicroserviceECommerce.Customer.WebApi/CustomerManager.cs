using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace MicroserviceECommerce.Customer.WebApi
{
    public static class CustomerManager
    {
        static Repository<Customers> repo = new Repository<Customers>();
        public static List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> customers = repo.List().Select(x => new CustomerModel()
            {
                CustomerID = x.CustomerID,
                Password = x.Password,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,  
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                Phone = x.Phone,
                Fax = x.Fax

            }).ToList();

            return customers; ;
        }

        public static Customers GetCustomer(string id)
        {
            Customers customer = repo.Find(y => y.CustomerID == id);
            return customer;
        }

        public static void UpdateCustomer(Customers cust)
        {
            repo.Update(cust);
        }

        public static void DeleteCustomer(Customers cust)
        {
            repo.Delete(cust);
        }

        public static void AddCustomer(Customers cust)
        {
            repo.Insert(cust);
        }

        public static void FillCustomer(Customers customer, Customers cust)
        {
            customer.Address = cust.Address;
            customer.City = cust.City;
            customer.Region = cust.Region;
            customer.PostalCode = cust.PostalCode;
            customer.CompanyName = cust.CompanyName;
            customer.ContactName = cust.ContactName;
            customer.Country = cust.Country;
            customer.Password = cust.Password;
            customer.Phone = cust.Phone;
            customer.Fax = cust.Fax;
            customer.ContactTitle = cust.ContactTitle;
        }
    }
}