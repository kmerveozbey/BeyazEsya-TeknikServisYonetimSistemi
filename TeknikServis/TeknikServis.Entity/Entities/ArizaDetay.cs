using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("ArizaDetaylari")]
    public class ArizaDetay
    {
        [Key]
        [Column(Order = 1)]
        public int ArizaID { get; set; }
        [ForeignKey("ArizaID")]
        public virtual ArizaKayit ArizaKayit { get; set; }

        [Required]
        public string Konum { get; set; }

        [Required]
        public string Mesaj { get; set; }

        public virtual List<Dosya> Dosyalar { get; set; } = new List<Dosya>();

    }
}