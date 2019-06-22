using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class LoginContoller:ApiController
    {
        RepositoryPattern<Customers> repo = new RepositoryPattern<Customers>();

      
    }
}