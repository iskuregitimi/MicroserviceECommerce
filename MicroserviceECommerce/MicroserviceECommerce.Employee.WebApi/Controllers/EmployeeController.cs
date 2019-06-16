using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        [HttpGet]
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = EmployeeManager.GetEmployees();
            return employees;
        }

        [HttpGet]
        public Employees GetEmployee(int id)
        {
            Employees employee = EmployeeManager.GetEmployee(id);
            return employee;
        }

        [HttpPost]
        public void AddEmployee(Employees emp)
        {
            Employees employee = new Employees();
            EmployeeManager.FillEmployee(employee, emp);
            EmployeeManager.AddEmployee(employee);
        }

        [HttpPost]
        public void UpdateEmployee(Employees emp)
        {
            Employees employee = EmployeeManager.GetEmployee(emp.EmployeeID);
            EmployeeManager.FillEmployee(employee, emp);
            EmployeeManager.UpdateEmployee(employee);
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            Employees employee = EmployeeManager.GetEmployee(id);
            EmployeeManager.DeleteEmployee(employee);
        }
    }
}