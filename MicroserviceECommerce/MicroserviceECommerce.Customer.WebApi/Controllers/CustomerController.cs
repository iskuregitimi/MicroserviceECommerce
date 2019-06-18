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
        [HttpGet]
        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> customers = CustomerManager.GetCustomers();
            return customers;
        }

        [HttpGet]
        public Customers GetCustomer(string id)
        {
            Customers customer = CustomerManager.GetCustomer(id);
            return customer;
        }

        [HttpPost]
        public void AddCustomer(Customers cust)
        {
            Customers customer = new Customers();
            customer.CustomerID = cust.CompanyName.Substring(0, 5).ToString();
            CustomerManager.FillCustomer(customer, cust);
            CustomerManager.AddCustomer(customer);
        }

        [HttpPost]
        public void UpdateCustomer(Customers cust)
        {
            Customers customer = CustomerManager.GetCustomer(cust.CustomerID);
            CustomerManager.FillCustomer(customer, cust);
            CustomerManager.UpdateCustomer(customer);
        }

        [HttpDelete]
        public void DeleteCustomer(string id)
        {
            Customers customer = CustomerManager.GetCustomer(id);
            List<Orders> orders = CustomerManager.GetOrder(customer);

            foreach (var item in orders)
            {
                List<Order_Details> orderDetails = CustomerManager.GetOrderDetail(item);

                foreach (var item2 in orderDetails)
                {
                    CustomerManager.DeleteOrderDetail(item2);
                }

                CustomerManager.DeleteOrder(item);
            }
           
            CustomerManager.DeleteCustomer(customer);
        }
    }
}