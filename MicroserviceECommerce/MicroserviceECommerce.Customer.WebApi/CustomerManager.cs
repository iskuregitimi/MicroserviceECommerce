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
        static Repository<Orders> orderRepo = new Repository<Orders>();
        static Repository<Order_Details> orderDetailRepo = new Repository<Order_Details>();

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

        public static List<Orders> GetOrder(Customers customer)
        {
            List<Orders> order = orderRepo.List().Where(x => x.CustomerID == customer.CustomerID).ToList();
            return order;
        }

        public static List<Order_Details> GetOrderDetail(Orders order)
        {
            List<Order_Details> orderDetail = orderDetailRepo.List().Where(x => x.OrderID == order.OrderID).ToList();
            return orderDetail;
        }

        public static void UpdateCustomer(Customers cust)
        {
            repo.Update(cust);
        }

        public static void DeleteCustomer(Customers cust)
        {
            repo.Delete(cust);
        }

        public static void DeleteOrder(Orders order)
        {
            orderRepo.Delete(order);
        }

        public static void DeleteOrderDetail(Order_Details orderDetail)
        {
            orderDetailRepo.Delete(orderDetail);
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