namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gundem")]
    public partial class Gundem
    {
        public int GundemId { get; set; }

        public int? HaberId { get; set; }

        public int? Sira { get; set; }

        public virtual Haberler Haberler { get; set; }
    }
}
