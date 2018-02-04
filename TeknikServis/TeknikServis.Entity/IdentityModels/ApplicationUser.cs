using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;

namespace TeknikServis.Entity.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(25)]
        public string Ad { get; set; }
        [StringLength(25)]
        public string Soyad { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
        public string AktivasyonKodu { get; set; }
        public virtual List<ArizaKayit> ArizaKayitlari { get; set; } = new List<ArizaKayit>();
        public virtual List<Message> Mesajlar { get; set; } = new List<Message>();
        
        public virtual List<Anket> Anketler { get; set; } = new List<Anket>();
        public virtual List<Teknisyen> Teknisyenler { get; set; } = new List<Teknisyen>();

    }
}

