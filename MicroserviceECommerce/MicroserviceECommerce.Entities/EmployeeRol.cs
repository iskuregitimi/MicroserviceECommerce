namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeRol")]
    public partial class EmployeeRol
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public int AuthorityID { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual Rols Rols { get; set; }
    }
}
