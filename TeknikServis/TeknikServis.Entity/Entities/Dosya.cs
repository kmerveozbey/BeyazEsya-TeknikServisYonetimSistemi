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
        public int? ArizaDetayID { get; set; }

        [ForeignKey("ArizaDetayID")]
        public virtual ArizaDetay ArizaDetay { get; set; }
    }
}

