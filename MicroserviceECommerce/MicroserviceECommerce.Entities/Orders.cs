namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable]

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            Order_Details = new HashSet<Order_Details>();
        }
      
        [Key]
        public int OrderID { get; set; }
    
        [StringLength(5)]
        public string CustomerID { get; set; }
        [DataMember]
        public int? EmployeeID { get; set; }
        [DataMember]
        public DateTime? OrderDate { get; set; }
        [DataMember]
        public DateTime? RequiredDate { get; set; }
        [DataMember]
        public DateTime? ShippedDate { get; set; }
        [DataMember]
        public int? ShipVia { get; set; }
        [DataMember]
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }
        [DataMember]
        [StringLength(40)]
        public string ShipName { get; set; }
        [DataMember]
        [StringLength(60)]
        public string ShipAddress { get; set; }
        [DataMember]
        [StringLength(15)]
        public string ShipCity { get; set; }
        [DataMember]
        [StringLength(15)]
        public string ShipRegion { get; set; }
        [DataMember]
        [StringLength(10)]
        public string ShipPostalCode { get; set; }
        [DataMember]
        [StringLength(15)]
        public string ShipCountry { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Status { get; set; }
        [DataMember]
        public virtual Customers Customers { get; set; }
        [DataMember]
        public virtual Employees Employees { get; set; }
        [DataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Details> Order_Details { get; set; }

        //public virtual Shippers Shippers { get; set; }
    }
}
