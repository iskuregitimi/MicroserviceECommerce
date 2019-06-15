namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kategori")]
    public partial class Kategori
    {
        public int KategoriId { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        [Required]
        public string Aciklama { get; set; }
    }
}
