namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SampleEmp")]
    public partial class SampleEmp
    {
        [Key]
        [Column(Order = 0)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        public string LastName { get; set; }
    }
}
