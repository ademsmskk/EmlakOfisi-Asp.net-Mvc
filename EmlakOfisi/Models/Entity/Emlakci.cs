namespace EmlakOfisi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Emlakci")]
    public partial class Emlakci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emlakci()
        {
            İlanBilgileri = new HashSet<İlanBilgileri>();
        }

        public int EmlakciID { get; set; }

        [Required]
        [StringLength(50)]
        public string EmlakciAdi { get; set; }

        [StringLength(20)]
        public string Sifre { get; set; }

        [StringLength(15)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(100)]
        public string Adres { get; set; }

        [Required]
        [StringLength(50)]
        public string FirmaAdi { get; set; }

        [Required]
        [StringLength(25)]
        public string KullaniciAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<İlanBilgileri> İlanBilgileri { get; set; }
    }
}
