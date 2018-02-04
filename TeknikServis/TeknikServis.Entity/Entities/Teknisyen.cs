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
    [Table("Teknisyenler")]
    public class Teknisyen
    {
        [Key]
        public int ID { get; set; }

        public string UyeId { get; set; }
        [ForeignKey("UyeId")]
        public virtual ApplicationUser Uye { get; set; }
        
        [Required]
        public bool BostaMi { get; set; } = true;

        public virtual List<ArizaKayit> ArizaKayitlari { get; set; } = new List<ArizaKayit>();

    }
}

