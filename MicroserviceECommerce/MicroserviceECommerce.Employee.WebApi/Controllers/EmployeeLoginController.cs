using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeLoginController:ApiController
    {
        DataContext db = new DataContext();
        [HttpGet]
        public EmployeeModel GetEmployee(string id, string password)
        {
            EmployeeModel employee = db.Employees.Where(x => x.UserName == id && x.Password == password).Select(y=> new EmployeeModel {
                EmployeeID=y.EmployeeID,
                LastName =y.LastName,
               FirstName=y.FirstName,
               TitleOfCourtesy=y.TitleOfCourtesy,
               Adress=y.Address,
               City=y.City,
               Region=y.Region,
               PostalCode=y.PostalCode,
               Country=y.Country,
               Notes=y.Notes,
               Password=y.Password,
               username=y.UserName              
            }).FirstOrDefault();
            return employee;
        }
    }
}