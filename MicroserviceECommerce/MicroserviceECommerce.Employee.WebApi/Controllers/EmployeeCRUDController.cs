using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeCRUDController:ApiController
    {
        DataContext db = new DataContext();
        //list employees if he is admin
        public List <EmployeeModel> GetEmployees()
        {
            var employees = db.Employees.Select(y => new EmployeeModel {
                EmployeeID = y.EmployeeID,
                LastName = y.LastName,
                FirstName = y.FirstName,
                TitleOfCourtesy = y.TitleOfCourtesy,
                Adress = y.Address,
                City = y.City,
                Region = y.Region,
                PostalCode = y.PostalCode,
                Country = y.Country,
                Notes = y.Notes,
                Password = y.Password,
                username=y.UserName
            }).ToList();
            return employees;
        }
        //Add employee if he is admin
        public void AddEmployee(Employees _employee)
        {
            db.Employees.Add(_employee);
            db.SaveChanges();
        }
        //Update Employee
        public void UpdateEmployee(Employees _employee)
        {
            Employees employee = db.Employees.FirstOrDefault(e => e.EmployeeID == _employee.EmployeeID);
            employee.FirstName = _employee.FirstName;
            employee.LastName = _employee.LastName;
            employee.Title = _employee.Title;
            employee.TitleOfCourtesy = _employee.TitleOfCourtesy;
            employee.Address = _employee.Address;
            employee.City = _employee.City;
            employee.Country = _employee.Country;
            employee.Notes = _employee.Notes;
            employee.PostalCode = _employee.PostalCode;
            employee.Password = _employee.Password;
            db.SaveChanges();

        }
        //Delete Employee if he is admin
        public void DeleteEmployee(int id)
        {
            Employees employee = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}