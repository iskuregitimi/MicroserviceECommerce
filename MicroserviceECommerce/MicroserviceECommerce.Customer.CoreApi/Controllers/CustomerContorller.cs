using MicroserviceECommerce.Customer.CoreApi.Models;
using MicroserviceECommerce.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceECommerce.Customer.CoreApi.Controllers
{
    public class CustomerContorller:Controller
    {
        DataContext dataContext = new DataContext();
        public List<ModelCustomer> GetCustomers()
        {
            List<ModelCustomer> DataCustomersList = dataContext.Customers.Tolist();
            return DataCustomersList;
        }
    }
}
