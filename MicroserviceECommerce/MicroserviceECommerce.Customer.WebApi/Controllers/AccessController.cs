using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class AccessController : ApiController
    {
        public static Entities.Customer LoginUser(LoginModel model)
        {
            if (string.IsNullOrEmpty(model.CustomerID) || string.IsNullOrEmpty(model.Password))
            {
                throw new MissingFieldException("kullanıcı adı yada şifreyi boş gönderemezsiniz");
            }

            DataContext data = new DataContext();
            var customer = data.Customers.FirstOrDefault(e => e.CustomerID == model.CustomerID && e.Password == model.Password);
            return customer;
        }
    }
}
