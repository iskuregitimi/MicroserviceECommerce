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
            List<EmployeeModell> employeeModell = new List<EmployeeModell>();
            var employe= employee_repo.List();


            foreach (var item in employe)
            {

                EmployeeModell model = new EmployeeModell
                {
                    Password = item.Password,
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    Title = item.Title,
                    TitleOfCourtesy = item.TitleOfCourtesy,
                    BirthDate = item.BirthDate,
                    HireDate = item.HireDate,
                    Address = item.Address,
                    City = item.City,
                    Region = item.Region,
                    PostalCode = item.PostalCode,
                    Country = item.Country,
                    HomePhone = item.HomePhone,
                    Extension = item.Extension,
                    Photo = item.Photo,
                    Notes = item.Notes,
                    ReportsTo = item.ReportsTo,
                    PhotoPath = item.PhotoPath
                };
                employeeModell.Add(model);
                
            }
            return employeeModell;
        }

    }
}
