using MicroserviceECommerce.Customer.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomersController : ApiController
    {
        DataContext data = new DataContext();

        public List<ModelCustomer> GetAll()
        {
            List<Entities.Customer> customerListinData = data.Customers.ToList();
            List<ModelCustomer> modelCustomerList = new List<ModelCustomer>();

            foreach (var customer in customerListinData)
            {
                ModelCustomer modelCustomer = new ModelCustomer
                {
                    CustomerID = customer.CustomerID,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    CompanyName = customer.CompanyName,
                    Country = customer.Country,
                    Address = customer.Address,
                    City = customer.City,
                    PostalCode = customer.PostalCode,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    Region = customer.Region,
                    Password = customer.Password
                };
                modelCustomerList.Add(modelCustomer);
            }
            return modelCustomerList;
        }
        public ModelCustomer GetWithId(string Id)
        {
            Entities.Customer customer = data.Customers.FirstOrDefault(x => x.CustomerID == Id);
            ModelCustomer modelCustomer = new ModelCustomer
            {
                CustomerID = customer.CustomerID,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                CompanyName = customer.CompanyName,
                Country = customer.Country,
                Address = customer.Address,
                City = customer.City,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Region = customer.Region,
                Password = customer.Password
            };

            return modelCustomer;
        }
        public int PostAdd(Entities.Customer customer)
        {
            customer.CustomerID = customer.CompanyName.Substring(0, 5);
            data.Customers.Add(customer);
            int result = data.SaveChanges();
            return result;
        }
        [HttpPost]
        public int Update(Entities.Customer _newCustomer)
        {
            Entities.Customer oldCustomer = data.Customers.FirstOrDefault(x => x.CustomerID == _newCustomer.CustomerID);

            oldCustomer.CompanyName = _newCustomer.CompanyName;
            oldCustomer.ContactName = _newCustomer.ContactName;
            oldCustomer.ContactTitle = _newCustomer.ContactTitle;
            oldCustomer.Country = _newCustomer.Country;
            oldCustomer.Address = _newCustomer.Address;
            oldCustomer.City = _newCustomer.City;
            oldCustomer.PostalCode = _newCustomer.PostalCode;
            oldCustomer.Phone = _newCustomer.Phone;
            oldCustomer.Fax = _newCustomer.Fax;
            oldCustomer.Region = _newCustomer.Region;
            oldCustomer.Password = _newCustomer.Password;
            int result = data.SaveChanges();
            return result;
        }

        public int Delete(string Id)
        {
            Entities.Customer customer = data.Customers.FirstOrDefault(x => x.CustomerID == Id);
            var orders = data.Orders.Where(x => x.CustomerID == customer.CustomerID).ToList();

            foreach (var item in orders)
            {
                var details = data.Order_Details.Where(x => x.OrderID == item.OrderID).ToList();

                foreach (var item2 in details)
                {
                    data.Order_Details.Remove(item2);
                }

                data.Orders.Remove(item);
            }

            data.Customers.Remove(customer);
            int result = data.SaveChanges();
            return result;
        }
    }
}