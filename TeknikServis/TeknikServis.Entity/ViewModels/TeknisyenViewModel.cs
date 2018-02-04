using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.ViewModels
{
  public  class TeknisyenViewModel
    {
        [Required]
        [Display(Name = "Ad")]
        public string Ad { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [Display(Name = "Teknisyen Müsait Mi?")]
        public bool BostaMi { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string UyeID { get; set; }
        public string RolID { get; set; }
    }
}
