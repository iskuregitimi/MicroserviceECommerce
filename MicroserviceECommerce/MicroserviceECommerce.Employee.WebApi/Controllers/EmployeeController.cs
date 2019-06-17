using MicroserviceECommerce.Employee.WebApi.Models;
using MicroserviceECommerce.Entities;
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
		RepositoryPattern<Employees> repo = new RepositoryPattern<Employees>();


		 public List<ModelEmployee> GetEmployeeList()
		{
			List<Employees> employeelist = repo.List();
			List<ModelEmployee> modelemployeelist = new List<ModelEmployee>();
			foreach(var employee in employeelist)
			{
				ModelEmployee modelemployee = new ModelEmployee
				{
					EmployeeID = employee.EmployeeID,
					BirthDate = employee.BirthDate,
					Extension = employee.Extension,
					Address = employee.Address,
					City = employee.City,
					FirstName = employee.FirstName,
					HireDate = employee.HireDate,
					Notes = employee.Notes,
					Photo = employee.Photo,
					HomePhone = employee.HomePhone,
					Region = employee.Region,
					PostalCode = employee.PostalCode,
					Country = employee.Country,
					LastName = employee.LastName,
					PhotoPath = employee.PhotoPath,
					Title = employee.Title,
					TitleOfCourtesy = employee.TitleOfCourtesy,
					ReportsTo = employee.ReportsTo

				};
				modelemployeelist.Add(modelemployee);
			}
			return modelemployeelist;
		}


		public List<ModelEmployee> GetEmployee(int id)
		{
			Employees employeelist = repo.Find(x=>x.);
			ModelEmployee modelemployeelist = new ModelEmployee();
			foreach (var employee in employeelist)
			{
				ModelEmployee modelemployee = new ModelEmployee
				{
					EmployeeID = employee.EmployeeID,
					BirthDate = employee.BirthDate,
					Extension = employee.Extension,
					Address = employee.Address,
					City = employee.City,
					FirstName = employee.FirstName,
					HireDate = employee.HireDate,
					Notes = employee.Notes,
					Photo = employee.Photo,
					HomePhone = employee.HomePhone,
					Region = employee.Region,
					PostalCode = employee.PostalCode,
					Country = employee.Country,
					LastName = employee.LastName,
					PhotoPath = employee.PhotoPath,
					Title = employee.Title,
					TitleOfCourtesy = employee.TitleOfCourtesy,
					ReportsTo = employee.ReportsTo

				};
				modelemployeelist.Add(modelemployee);
			}
			return modelemployeelist;
		}


	}






	//public List<ModelCustomer> GetAll()
	//{
	//	List<Entities.Customer> customerListinData = data.Customers.ToList();
	//	List<ModelCustomer> modelCustomerList = new List<ModelCustomer>();

	//	foreach (var customer in customerListinData)
	//	{
	//		ModelCustomer modelCustomer = new ModelCustomer
	//		{
	//			CustomerID = customer.CustomerID,
	//			ContactName = customer.ContactName,
	//			ContactTitle = customer.ContactTitle,
	//			CompanyName = customer.CompanyName,
	//			Country = customer.Country,
	//			Address = customer.Address,
	//			City = customer.City,
	//			PostalCode = customer.PostalCode,
	//			Phone = customer.Phone,
	//			Fax = customer.Fax,
	//			Region = customer.Region,
	//			Password = customer.Password
	//		};
	//		modelCustomerList.Add(modelCustomer);
	//	}
	//	return modelCustomerList;
	//}

}
