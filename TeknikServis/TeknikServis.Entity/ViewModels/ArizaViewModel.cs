using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TeknikServis.Entity.ViewModels
{
    public class ArizaViewModel
    {

        [Required]
        [Display(Name = "Arıza Kayıt ID")]
        public int ArizaId { get; set; }

        [Required]
        [Display(Name = "Uye ID")]
        public string UyeId { get; set; }

        [Display(Name = "Uye Adı")]
        public string UyeAdı { get; set; }

        [Display(Name = "Teknisyen ID")]
        public int? TeknisyenID { get; set; }

        [Required]
        public string LocationX { get; set; }

        [Required]
        public string LocationY { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefon Numarası")]
        public string TelNo { get; set; }

        [Display(Name = "Arıza Durumu")]
        public string Durum { get; set; }

        [Required]
        [Display(Name = "Mesaj")]
        public string Mesaj { get; set; }
        public List<string> FotoUrList { get; set; } = new List<string>();
        [Display(Name = "Arıza Fotoğrafı")]
        public List<HttpPostedFileBase> Dosyalar { get; set; } = new List<HttpPostedFileBase>();
    }
}
