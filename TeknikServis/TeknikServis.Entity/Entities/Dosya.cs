using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("Dosyalar")]
    public class Dosya
    {
        [Key]
        public int ID { get; set; }
        public string DosyaYolu { get; set; }
        public string Uzanti { get; set; }
        public int? ArizaID { get; set; }

        [ForeignKey("ArizaID")]
        public virtual ArizaKayit Ariza { get; set; }
    }
}

