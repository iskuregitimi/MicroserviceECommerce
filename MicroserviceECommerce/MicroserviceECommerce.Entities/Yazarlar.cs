namespace MicroserviceECommerce.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yazarlar")]
    public partial class Yazarlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yazarlar()
        {
            KoseYazilari = new HashSet<KoseYazilari>();
        }

        [Key]
        public int YazarId { get; set; }

        [StringLength(50)]
        public string AdiSoyadi { get; set; }

        [StringLength(250)]
        public string ResimUrl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KoseYazilari> KoseYazilari { get; set; }
    }
}
