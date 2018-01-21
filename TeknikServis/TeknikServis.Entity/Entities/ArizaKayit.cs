using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.Entities
{
    [Table("ArizaKayitlari")]
    public class ArizaKayit
    {
        [Key]
        public int ID { get; set; }

        public string UyeId { get; set; }
        [ForeignKey("UyeId")]
        public virtual ApplicationUser Uye { get; set; }

        public int? TeknisyenID { get; set; }
        [ForeignKey("TeknisyenID")]
        public virtual Teknisyen Teknisyen { get; set; }

        public virtual List<ArizaDurumDetay> ArizaDurumDetaylari { get; set; } = new List<ArizaDurumDetay>();
        public virtual List<ArizaDetay> ArizaDetaylari { get; set; } = new List<ArizaDetay>();

    }
}
