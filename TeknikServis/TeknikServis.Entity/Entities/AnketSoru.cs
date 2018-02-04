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
        
        [Required]
        public string Soru { get; set; }

        public int Cevap { get; set; }

        public virtual List<Anket> Anketler { get; set; } = new List<Anket>();


    }
}
