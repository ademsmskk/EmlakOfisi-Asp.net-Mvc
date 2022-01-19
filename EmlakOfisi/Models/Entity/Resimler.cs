namespace EmlakOfisi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resimler")]
    public partial class Resimler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Resimler()
        {
            İlanBilgileri = new HashSet<İlanBilgileri>();
        }

        [Key]
        public int ResimID { get; set; }

        public string OrtaYol { get; set; }

        public string BüyükYol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<İlanBilgileri> İlanBilgileri { get; set; }
    }
}
