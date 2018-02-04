using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Enums;

namespace TeknikServis.Entity.Entities
{
    [Table("ArizaDurumDetaylari")]
    public class ArizaDurumDetay
    {
        [Key]
        public int ID { get; set; }
        public int ArizaKayitID { get; set; }
        [ForeignKey("ArizaKayitID")]
        public virtual ArizaKayit ArizaKayit { get; set; }

        [Required]
        public string YapilanIslemler { get; set; }

        [Required]
        public GarantiTipi GarantiTipi { get; set; }

        public decimal ToplamTutar { get; set; } = 0;

        [Required]
        public bool IslemBittiMi { get; set; } = false;
    }
}
