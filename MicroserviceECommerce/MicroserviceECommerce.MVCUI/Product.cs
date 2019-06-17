﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI
{
    public class Product
    {
        public class Products
        {
            public Categori Categories { get; set; }
            public Supplier Suppliers { get; set; }
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public double UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
            public int UnitsOnOrder { get; set; }
            public int ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
        }
    }
}