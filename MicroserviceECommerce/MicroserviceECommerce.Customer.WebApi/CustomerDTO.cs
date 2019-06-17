﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.Customer.WebApi
{
	public class CustomerDTO
	{
		public string CustomerID { get; set; }


		public string Password { get; set; }


		public string CompanyName { get; set; }


		public string ContactName { get; set; }

		public string ContactTitle { get; set; }


		public string Address { get; set; }


		public string City { get; set; }
	



		public string Country { get; set; }

		public string Phone { get; set; }
	}
}