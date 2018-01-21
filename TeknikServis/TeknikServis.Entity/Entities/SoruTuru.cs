using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entities
{
    [Table("SoruTurleri")]
    public class SoruTuru
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Turu { get; set; }

        public virtual List<AnketSoru> AnketSorulari { get; set; } = new List<AnketSoru>();
        public virtual List<Anket> Anketler{ get; set; } = new List<Anket>();

    }
}

