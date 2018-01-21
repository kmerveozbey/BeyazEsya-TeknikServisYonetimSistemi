using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.ViewModels
{
    public class ProfileViewModel
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
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string EskiSifre { get; set; }


        [StringLength(100)]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z]\w{4,14}$", ErrorMessage = @"	
The password's first character must be a letter, it must contain at least 5 characters and no more than 15 characters and no characters other than letters, numbers and the underscore may be used")]
        public string YeniSifre { get; set; }


        [StringLength(100)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor")]
        public string YeniSifreTekrar { get; set; }
    }
}

