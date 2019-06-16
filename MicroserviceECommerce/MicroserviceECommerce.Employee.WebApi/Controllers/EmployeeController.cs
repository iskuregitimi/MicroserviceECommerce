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
        public List<Employees> GetEmployees()
        {
            List<Employees> employees = repo.List();
            return employees;
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