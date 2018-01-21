using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("AnketSorulari")]
    public class AnketSoru
    {
        [Key]
        public int ID { get; set; }

        public int SoruTuruId { get; set; }
        [ForeignKey("SoruTuruId")]
        public virtual SoruTuru SoruTuru { get; set; }

        [Required]
        public string Soru { get; set; }

    }
}
