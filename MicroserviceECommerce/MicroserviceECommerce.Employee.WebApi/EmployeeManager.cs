using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.Employee.WebApi
{
    public static class EmployeeManager
    {
        static Repository<Employees> repo = new Repository<Employees>();
        public static List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = repo.List().Select(x => new EmployeeModel()
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

            return employees; ;
        }

        public static Employees GetEmployee(int id)
        {
            Employees employee = repo.Find(y => y.EmployeeID == id);
            return employee;
        }

        public static void UpdateEmployee(Employees emp)
        {
            repo.Update(emp);
        }

        public static void DeleteEmployee(Employees emp)
        {
            repo.Delete(emp);
        }

        public static void AddEmployee(Employees emp)
        {
            repo.Insert(emp);
        }

        public static void FillEmployee(Employees employee, Employees emp)
        {
            employee.LastName = emp.LastName;
            employee.FirstName = emp.FirstName;
            employee.Title = emp.Title;
            employee.TitleOfCourtesy = emp.TitleOfCourtesy;
            employee.BirthDate = emp.BirthDate;
            employee.HireDate = emp.HireDate;
            employee.Address = emp.Address;
            employee.City = emp.City;
            employee.Region = emp.Region;
            employee.PostalCode = emp.PostalCode;
            employee.Country = emp.Country;
            employee.HomePhone = emp.HomePhone;
            employee.Extension = emp.Extension;
            employee.Photo = emp.Photo;
            employee.Notes = emp.Notes;
            employee.ReportsTo = emp.ReportsTo;
            employee.PhotoPath = emp.PhotoPath;
            employee.Password = emp.Password;
        }
    }
}