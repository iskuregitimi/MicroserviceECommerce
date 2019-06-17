using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;

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

        Repository<Employees> employee_repo = new Repository<Employees>();
       
     

        public List<EmployeeModell> GetEmployees()
        {
            
            List<EmployeeModell> employees = employee_repo.List().Select(x => new EmployeeModell()
            {
                EmployeeID = x.EmployeeID,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy,
                BirthDate = x.BirthDate.Value,
                HireDate = x.HireDate.Value,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                HomePhone = x.HomePhone,
                Extension = x.Extension,
                Notes = x.Notes,
                ReportsTo = x.ReportsTo.Value,
                PhotoPath = x.PhotoPath,
                Password = x.Password
            }).ToList();

            return employees; 
        }


        public void InsertEmployee(Employees model)
        {
            Employees employee = new Employees();
      

            employee.LastName = model.LastName;
            employee.FirstName = model.FirstName;
            employee.Title = model.Title;
            employee.TitleOfCourtesy = model.TitleOfCourtesy;
            employee.BirthDate = model.BirthDate;
            employee.HireDate = model.HireDate;
            employee.Address = model.Address;
            employee.City = model.City;
            employee.Region = model.Region;
            employee.PostalCode = model.PostalCode;
            employee.Country = model.Country;
            employee.HomePhone = model.HomePhone;
            employee.Extension = model.Extension;
            employee.Photo = model.Photo;
            employee.Notes = model.Notes;
            employee.ReportsTo = model.ReportsTo;
            employee.PhotoPath = model.PhotoPath;
            employee.Password = model.Password;
            employee_repo.Insert(employee);

        }

    }
}
