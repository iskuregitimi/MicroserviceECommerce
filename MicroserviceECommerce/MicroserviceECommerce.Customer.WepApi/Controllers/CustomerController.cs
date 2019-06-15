using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WepApi.Controllers
{
    public class CustomerController : ApiController    // BEN ANLAMIYORUM METOD YAZMA İŞİ SADECE CONTOLLAR DA YPILMAYACAKMI BEN NERDE YAZIYORUM ONU DA BİLMİYORMİ
    {
        [HttpGet]
        public List<customerDTO> ListCustomers()
        {
            CustomrBLL customerbll = new CustomrBLL();
            List<customerDTO> customers = customerbll.ListCustomers();
            return customers;

        }
      
        [HttpPost]
        public string  AddCustomer(Customers model)
        {
            CustomrBLL customerbll = new CustomrBLL();
            Customers c = new Customers();
            c.Address = model.Address;
            c.City = model.City;
            c.CompanyName = model.CompanyName;
            c.ContactName = model.ContactName;
            c.Country = model.Country;
            c.CustomerID = model.CustomerID;
            c.Password = model.Password;
            c.Phone = model.Phone;
            c.ContactTitle = model.ContactTitle;
            
            customerbll.CreateCustomer(c);

            return c.CustomerID + "database eklendi";
        }
        [HttpGet]
        public Customers GetCustomer(string id)
        {
            CustomrBLL customerbll = new CustomrBLL();
           Customers c= customerbll.GetoneCustomer(id);
            return c;


        }
        public void UpdateCustomer(Customers custom)
        {
            CustomrBLL customerbll = new CustomrBLL();
            Customers c = customerbll.GetoneCustomer(custom.CustomerID);
            c.CustomerID = custom.CustomerID;
            c.CompanyName = custom.CompanyName;
            c.ContactName=custom.ContactName;
            c.ContactTitle = custom.ContactTitle;
            c.City = custom.City;
            c.Country = custom.Country;
            c.Password = c.Password;
            c.Phone = c.Phone;
            c.Address = c.Address;
            customerbll.UpdateCustomer(c);




        }
    }
}
