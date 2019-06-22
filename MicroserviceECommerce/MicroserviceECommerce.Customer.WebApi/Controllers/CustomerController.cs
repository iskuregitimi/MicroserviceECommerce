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
        DataContext dataContext = new DataContext();
        public List<CustomerModel> GetCustomers()
        {
            List<Customers> DataCustomersList = dataContext.Customers.ToList();
            List<CustomerModel> customerModelList = new List<CustomerModel>();
            foreach (var item in DataCustomersList)// item yakalanan Customer'e verdiğimiz değişken 
            {
                CustomerModel customerModel = new CustomerModel
                {
                    CustomerID = item.CustomerID,
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
                customerModelList.Add(customerModel);

            }
            return customerModelList;
        }
        public CustomerModel GetCustomer(string id)
        {
            Customers customer = dataContext.Customers.FirstOrDefault(x => x.CustomerID == id);
            CustomerModel customerModel = new CustomerModel
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
            return customerModel;
        }
        public void AddCustomer(CustomerModel customer)
        {
            Customers newcustomer = new Customers
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
            dataContext.Customers.Add(newcustomer);
            dataContext.SaveChanges();
        }
        [HttpDelete]
        public void DeleteCustomer(string id)
        {
            Customers customer = dataContext.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            dataContext.Customers.Remove(customer);
            dataContext.SaveChanges();
        }
        [HttpPost]
        public void EditCustomer(CustomerModel updatedCustomer)
        {
            Customers customer = dataContext.Customers.Where(x => x.CustomerID == updatedCustomer.CustomerID).FirstOrDefault();
            customer.Address = updatedCustomer.Address;
            customer.City = updatedCustomer.City;
            customer.CompanyName = updatedCustomer.CompanyName;
            customer.ContactName = updatedCustomer.ContactName;
            customer.ContactTitle = updatedCustomer.ContactTitle;
            customer.Country = updatedCustomer.Country;
            customer.Fax = updatedCustomer.Fax;
            customer.Password = updatedCustomer.Password;
            customer.Phone = updatedCustomer.Phone;
            customer.PostalCode = updatedCustomer.PostalCode;
            customer.Region = updatedCustomer.Region;
            dataContext.SaveChanges();
        }







    }
}