namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Roller")]
    public partial class Roller
    {
        [Key]
        [Column(Order = 0)]
        public int RolID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Rolü { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
