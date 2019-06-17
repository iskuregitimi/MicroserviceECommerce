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
        DataContext dataContext = new DataContext();
        public List<ModelCustomer> GetCustomers()
        {
            List<Customers> DataCustomersList= dataContext.Customers.ToList();
            List<ModelCustomer> modelCustomersList = new List<ModelCustomer>();
            foreach (var item in DataCustomersList)// item yakalanan Customer'e verdiğimiz değişken 
            {
                ModelCustomer modelCustomer = new ModelCustomer
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
                    PostalCode = item.PostalCode

                };
                modelCustomersList.Add(modelCustomer);
              
            }
            return modelCustomersList;
        }
        
    }
}