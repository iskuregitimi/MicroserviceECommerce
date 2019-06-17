using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeController:ApiController
    {
        RepositoryPattern<Employees> repo = new RepositoryPattern<Employees>();

        [HttpGet]
        public List<EmployeeModel> GetEmployees()
        {
            using (DataContext db=new DataContext())
            {
                return db.Employees.Select(x => new EmployeeModel
                {
                    Address=x.Address,
                    BirthDate=x.BirthDate,
                    City=x.City,
                    Country=x.Country,
                    EmployeeID=x.EmployeeID,
                    FirstName=x.FirstName,
                    HireDate=x.HireDate,
                    HomePhone=x.HomePhone,
                    LastName=x.LastName,
                    Password=x.Password,
                    PostalCode=x.PostalCode,
                    Region=x.Region,
                    Title=x.Title,
                   TitleOfCourtesy=x.TitleOfCourtesy,
                   
                }).ToList();
            }
         
        }

        [HttpGet]
        public Employees FindEmployee(int id)
        {
            Employees employee = repo.Find(x => x.EmployeeID == id);
            return employee;
        }
     
        public void AddEmployee(Employees employee)
        {
            repo.Insert(employee);
        }
    }
}