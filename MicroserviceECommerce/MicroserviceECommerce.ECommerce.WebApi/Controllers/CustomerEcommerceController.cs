

using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class CustomerEcommerceController : ApiController
    {
        [HttpGet]
        public List<orderTO> Listorders(string id)
        {
            orderbll customerbll = new orderbll();
            List<orderTO> s = customerbll.Listorder(id);
            return s;

        }
        [HttpGet]
        public customrDTO GetCustomer(string id)
        {
            orderbll customerbll = new orderbll();
            customrDTO c = customerbll.onecust(id);
            return c;


        }
        [HttpGet]

        public List<Order_Details> OrderDetailList (int id)
        {
            orderbll customerbll = new orderbll();
            var orderdetails = customerbll.getorderdetails(id);
            return orderdetails;
        }

    }
}
