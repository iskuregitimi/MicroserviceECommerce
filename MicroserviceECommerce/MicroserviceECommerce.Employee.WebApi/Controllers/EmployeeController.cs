using MicroserviceECommerce.Entities;
using MicroserviceECommerce.Entities.Models;
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
        DataContext data = new DataContext();

        public List<ModelEmployee> GetAll()
        {
            List<Entities.Employee> employeeListinData = data.Employees.ToList();
            List<ModelEmployee> modelEmployeeList = new List<ModelEmployee>();

            foreach (var employee in employeeListinData)
            {
                ModelEmployee modelEmployee = new ModelEmployee
                { 
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BirthDate = employee.BirthDate,
                    Address = employee.Address,
                    City = employee.City,
                    Country = employee.Country,
                    PostalCode = employee.PostalCode,
                    Extension = employee.Extension,
                    HireDate = employee.HireDate,
                    HomePhone = employee.HomePhone,
                    Notes = employee.Notes,
                    Photo = employee.Photo,
                    PhotoPath = employee.PhotoPath,
                    Region = employee.Region,
                    ReportsTo = employee.ReportsTo,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy
                };
                modelEmployeeList.Add(modelEmployee);
            }
            return modelEmployeeList;
        }
        public ModelEmployee GetWithId(int Id)
        {
            Entities.Employee employee = data.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            ModelEmployee modelEmployee = new ModelEmployee
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Address = employee.Address,
                City = employee.City,
                Country = employee.Country,
                PostalCode = employee.PostalCode,
                Extension = employee.Extension,
                HireDate = employee.HireDate,
                HomePhone = employee.HomePhone,
                Notes = employee.Notes,
                Photo = employee.Photo,
                PhotoPath = employee.PhotoPath,
                Region = employee.Region,
                ReportsTo = employee.ReportsTo,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy
            };

            return modelEmployee;
        }
        [HttpPost]
        public void Add(Entities.Employee employee)
        {

            data.Employees.Add(employee);
            int result = data.SaveChanges();
            //return result;
        }
        [HttpPost]
        public int Update(Entities.Employee _newEmployee)
        {
            Entities.Employee oldEmployee = data.Employees.FirstOrDefault(x => x.EmployeeID == _newEmployee.EmployeeID);


            oldEmployee.FirstName = _newEmployee.FirstName;
            oldEmployee.LastName = _newEmployee.LastName;
            oldEmployee.BirthDate = _newEmployee.BirthDate;
            oldEmployee.Address = _newEmployee.Address;
            oldEmployee.City = _newEmployee.City;
            oldEmployee.Country = _newEmployee.Country;
            oldEmployee.PostalCode = _newEmployee.PostalCode;
            oldEmployee.Extension = _newEmployee.Extension;
            oldEmployee.HireDate = _newEmployee.HireDate;
            oldEmployee.HomePhone = _newEmployee.HomePhone;
            oldEmployee.Notes = _newEmployee.Notes;
            oldEmployee.Photo = _newEmployee.Photo;
            oldEmployee.PhotoPath = _newEmployee.PhotoPath;
            oldEmployee.Region = _newEmployee.Region;
            oldEmployee.ReportsTo = _newEmployee.ReportsTo;
            oldEmployee.Title = _newEmployee.Title;
            oldEmployee.TitleOfCourtesy = _newEmployee.TitleOfCourtesy;
            int result = data.SaveChanges();
            return result;
        }

        public int Delete(int Id)
        {
            Entities.Employee employee = data.Employees.FirstOrDefault(x => x.EmployeeID == Id);
            var orders = data.Orders.Where(x => x.EmployeeID == employee.EmployeeID).ToList();

            var territories = employee.Territories.ToList();
            foreach (var item in territories)
            {
                data.Territories.Remove(item);

            }

            foreach (var item in orders)
            {
                var details = data.Order_Details.Where(x => x.OrderID == item.OrderID).ToList();

                foreach (var item2 in details)
                {
                    data.Order_Details.Remove(item2);
                }

                data.Orders.Remove(item);
            }

            data.Employees.Remove(employee);
            int result = data.SaveChanges();
            return result;
        }
    }
}

