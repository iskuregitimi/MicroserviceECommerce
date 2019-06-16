﻿using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class HomeController : ApiController
    {
        Repository<EmployeeModell> employee_repo = new Repository<EmployeeModell>();

        public List<EmployeeModell> GetEmployees()
        {
            var employee = employee_repo.List();
            List<EmployeeModell> employeeModels = new List<EmployeeModell>();
            foreach (var item in employee)
            {
                EmployeeModell employ = new EmployeeModell
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
                employeeModels.Add(employ);

            }

            return employeeModels;

        }
    }
}
