using MicroserviceECommerce.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Views.Customer
{
    public class LoginController : Controller
    {
     
		[HttpGet]
		public ActionResult Login(Customers id)
		{
			id.CustomerID = id.CompanyName.Substring(0, 5);
			var client = new RestClient("http://localhost:37786/");
			var request = new RestRequest("api/Customer/Login", Method.GET);
			request.AddJsonBody(id);
			client.Execute(request);
			return RedirectToAction("CustomerList");

			
		}
    }
}