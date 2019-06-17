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

        public List<Orders> OrderListrelatedtoCustomer(string id)
        {
            List<Orders> o = db.Orders.Where(x => x.CustomerID == id).ToList();
            return o;


        }


        //public List<OrderDTO> Listorder(string id)
        //{

        //    List<OrderDTO> o = db.Orders.Select(x => new OrderDTO()
        //    {
        //        ShipAddress = x.ShipAddress,
        //        CustomerID = x.CustomerID,
        //        OrderID = x.OrderID,




        //    }).Where(x => x.CustomerID == id).ToList();




        //    return o;
        //}
        public customerDTO onecust(string id)
        {

            customerDTO customers = db.Customers.Select(x => new customerDTO()
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
            }).Where(x => x.CustomerID == id).FirstOrDefault();

            return customers;
        }








        public int DeleteCustomer(string id)
        {
            Customers customer = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();
            var Orders = db.Orders.Where(x => x.CustomerID == customer.CustomerID).ToList();       
           

            foreach (var item in Orders)
            {
                var details = db.Order_Details.Where(x => x.OrderID == item.OrderID).ToList();

                foreach (var item2 in details)
                {
                    db.Order_Details.Remove(item2);
                }

                db.Orders.Remove(item);
            }

            db.Customers.Remove(customer);
            int result = db.SaveChanges();
            return result;




        }



        //public void DeleteOrder(int id)
        //{
        //    Order_Details o = db.Order_Details.Where(x => x.OrderID == id).FirstOrDefault();
        //    db.Order_Details.Remove(o);
        //    db.SaveChanges();
        //}


    }
}