namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SampleEmp2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
