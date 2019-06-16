using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MicroserviceECommerce.Customer.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
		RepositoryPattern<Customers> repo = new RepositoryPattern<Customers>(); 

		[HttpGet]
		public List<Customers> CustomersList()
		{
			List<Customers> customer = repo.List();
			  return customer;


		}

		[HttpGet]
		public Customers GetCustomer(string id)
		{
			Customers result = repo.Find(x => x.CustomerID == id);
			return result;
		}

		[HttpPost]
		public void AddCustomer(Customers customer)
		{

			repo.Add(customer);
		}

		[HttpDelete]
		public void DeleteCustomer(string customerid)
		{

			var customer = repo.Find(x => x.CustomerID == customerid);
			repo.Delete(customer);
		}

	}
}
