using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI
{
    public class orderdetailsmodel
    {
      
        
            public Orders Orders { get; set; }
        public Product Products { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
            public int Quantity { get; set; }
            public double Discount { get; set; }
        
    }
}