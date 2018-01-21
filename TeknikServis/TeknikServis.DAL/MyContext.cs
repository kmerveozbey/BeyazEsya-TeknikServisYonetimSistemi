using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("name=MyCon2")
        { }
        public virtual DbSet<Message> Mesajlar { get; set; }
        public virtual DbSet<ArizaKayit> ArizaKayitlari { get; set; }
        public virtual DbSet<ArizaDurumDetay> ArizaDurumDetaylari { get; set; }
        public virtual DbSet<ArizaDetay> ArizaDetaylari { get; set; }
        public virtual DbSet<Teknisyen> Teknisyenler { get; set; }
        public virtual DbSet<Anket> Anketler { get; set; }
        public virtual DbSet<Dosya> Dosyalar { get; set; }
        public virtual DbSet<SoruTuru> SoruTurleri { get; set; }
        public virtual DbSet<AnketSoru> AnketSorulari { get; set; }
    }

}
