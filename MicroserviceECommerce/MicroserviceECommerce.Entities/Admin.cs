namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminID { get; set; }

        [Required]
        [StringLength(20)]
        public string AUser { get; set; }

        [Required]
        [StringLength(20)]
        public string APassword { get; set; }
    }
}
