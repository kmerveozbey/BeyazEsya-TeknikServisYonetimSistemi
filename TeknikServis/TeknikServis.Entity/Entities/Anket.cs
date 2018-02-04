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
    [Table("Anketler")]
    public class Anket
    {
        [Key]
        public int ID { get; set; }

        public string UyeId { get; set; }
        [ForeignKey("UyeId")]
        public virtual ApplicationUser Uye { get; set; }

        public int SoruID { get; set; }
        [ForeignKey("SoruID")]
        public virtual AnketSoru Soru { get; set; }
        
    }
}

