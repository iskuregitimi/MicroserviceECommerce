using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public List<EmployeeModel> GetEmployees()
        {
            EmployeeBL emp = new EmployeeBL();
            List<EmployeeModel> result = emp.ListEmployees();

            return result;
        }

    }
}
