using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

		RepositoryPattern<Employees> repo = new RepositoryPattern<Employees>();

		[HttpGet]
		public List<Employees> EmployeeList()
		{
			List<Employees> employee = repo.List();
			return employee;
		}

		[HttpGet]
		public Employees GetEmployee(int employeeid)
		{
			Employees result = repo.Find(x => x.EmployeeID == employeeid);
			return result;
		}

		[HttpPost]
		public void AddEpmloyee(Employees employee)
		{

			repo.Add(employee);
		}

		[HttpGet]
		public void DeleteEmployee(int employeeid)
		{

			var customer = repo.Find(x => x.EmployeeID == employeeid);
			repo.Delete(customer);
		}

	}
}
