namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_T
    {
        [Key]
       
        public int ID { get; set; }

        [Key]
 
        [StringLength(5)]
        public string CustomerID { get; set; }

        
        public string Token { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
