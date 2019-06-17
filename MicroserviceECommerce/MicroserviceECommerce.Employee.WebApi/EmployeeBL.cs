using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.Employee.WebApi
{
    public class EmployeeBL
    {
        static DataContext db = new DataContext();

        public List<EmployeeModel> ListEmployees()
        {

            List<EmployeeModel> emp = db.Employees.Select(x => new EmployeeModel()
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

            return emp;
        }
    }
}