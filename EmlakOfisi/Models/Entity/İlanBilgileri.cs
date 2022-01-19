namespace EmlakOfisi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class İlanBilgileri
    {
        [Key]
        public int İlanID { get; set; }

        public DateTime İlanTarihi { get; set; }

        public int EmlakciID { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public int OdaSayisi { get; set; }

        public int? BinaYasi { get; set; }

        [StringLength(50)]
        public string Balkon { get; set; }

        [Required]
        [StringLength(500)]
        public string Adres { get; set; }

        [Required]
        [StringLength(10)]
        public string Fiyat { get; set; }

        public int? ResimID { get; set; }

        public virtual Emlakci Emlakci { get; set; }

        public virtual Resimler Resimler { get; set; }
    }
}
