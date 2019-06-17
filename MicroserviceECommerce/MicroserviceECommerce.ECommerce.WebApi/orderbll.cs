
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.ECommerce.WebApi
{
    public class orderbll
    {
        static DataContext db = new DataContext();
        public customrDTO onecust(string id)
        {

            customrDTO customers = db.Customers.Select(x => new customrDTO()
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
        public List<orderTO> Listorder(string id)
        {

            List<orderTO> o = db.Orders.Select(x => new orderTO()
            {
                ShipAddress = x.ShipAddress,
                CustomerID = x.CustomerID,
                OrderID = x.OrderID,




            }).Where(x => x.CustomerID == id).ToList();




            return o;
        }

        public List<Order_Details> getorderdetails(int id)
        {
            var a = db.Order_Details.Where(x => x.OrderID == id).ToList();
            return a;
        }

    }
}