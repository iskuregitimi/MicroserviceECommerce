using MicroserviceECommerce.Employee.WebApi.Model;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MicroserviceECommerce.Employee.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        DataContext dataContext = new DataContext();
        public List<ModelEmployee> GetEmployees()
        {
            List<Employees> DataEmployeeList = dataContext.Employees.ToList();
            List<ModelEmployee> modelEmployeesList = new List<ModelEmployee>();

            foreach (var item in DataEmployeeList)
            {
                ModelEmployee modelEmployee = new ModelEmployee
                {
                    FirstName = item.FirstName,
                    LastName=item.LastName,
                    Password=item.Password,
                    Address = item.Address,
                    City = item.City,
                    Country = item.Country,
                    PostalCode=item.PostalCode,
                    Region=item.Region,
                    ReportsTo=item.ReportsTo,
                    Title=item.Title,
                    TitleOfCourtesy= item.TitleOfCourtesy,
                    EmployeeID=item.EmployeeID,
                    Extension=item.Extension,
                    HomePhone=item.HomePhone
                };
                modelEmployeesList.Add(modelEmployee);
            }

            return modelEmployeesList;
        }
    }
}