using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Entity.ViewModels;

namespace TeknikServis.MVC.Areas.ServisYonetim.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Anasayfa()
        {
            return View();
        }
        List<UserViewModel> model = new List<UserViewModel>();
        public void Kullanicilar()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.IsInRole("Admin"))
                {
                    var userManager = MembershipTools.NewUserManager();
                    var user = userManager.Users.ToList();
                    user.ForEach(item => model.Add(new UserViewModel()
                    {
                        Ad = item.Ad,
                        Soyad = item.Soyad,
                        Email = item.Email,
                        KullaniciAdi = item.UserName,
                        RolID = item.Roles.First()?.RoleId,
                    }));

                }
            }
        }
        public ActionResult KullanicilariListele()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            var userManager = MembershipTools.NewUserManager();
            userManager.Users.ToList()
            .ForEach(item => model.Add(new UserViewModel()
            {
                Ad = item.Ad,
                Soyad = item.Soyad,
                Email = item.Email,
                KullaniciAdi = item.UserName,
                RolID = item.Roles.First()?.RoleId,
            }));
            var rolManager = MembershipTools.NewRoleManager();
            var roller = rolManager.Roles.ToList();

            return View(model);
        }
        public ActionResult KullaniciEkle()
        {
            List<IdentityRoles> rollerim = Enum.GetValues(typeof(IdentityRoles)).Cast<IdentityRoles>().ToList();
            ViewBag.Roller = new SelectList(rollerim);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciEkle(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);
            var userManager = MembershipTools.NewUserManager();

            var checkUser = userManager.FindByName(model.Ad);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı adı daha önceden kayıt edilmiş");
                return View(model);
            }

            var activationCode = Guid.NewGuid().ToString().Replace("-", "");
            var user = new ApplicationUser()
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Email = model.Email,
                UserName = model.KullaniciAdi,
                PasswordHash = model.Sifre,
                AktivasyonKodu = activationCode,
                EmailConfirmed = true,
            };
            var sonuc = userManager.Create(user, model.Sifre);
            if (sonuc.Succeeded)
            {

                userManager.AddToRole(user.Id, model.RolAdi.ToString());
                if (model.RolAdi == TeknikServis.Entity.Enums.IdentityRoles.Teknisyen)
                {
                    List<TeknisyenViewModel> teknisyenModel = new List<TeknisyenViewModel>();
                    new TeknisyenRepo().Insert(new Teknisyen()
                    {
                        UyeId = user.Id,
                        BostaMi = true,
                    });

                }

                string siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
                                 (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                return RedirectToAction("KullanicilariListele", "Admin");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
                return View(model);
            }
        }


        public ActionResult YonlendirilmemisArizalar()
        {
            List<ArizaViewModel> model = new List<ArizaViewModel>();
            var userManager = MembershipTools.NewUserManager();
            new ArizaKayitRepo().GetAll().ToList()
            .ForEach(item => model.Add(new ArizaViewModel()
            {
                UyeId = item.Uye.Id,
                UyeAdı = MembershipTools.GetUserName(item.Uye.Id),
                Email = item.Email,
                Mesaj = item.Mesaj,
                TelNo=item.TelNo,
                TeknisyenID=item.TeknisyenID,
            }));
            var rolManager = MembershipTools.NewRoleManager();
            var roller = rolManager.Roles.ToList();
            return View(model.Where(x=>x.TeknisyenID==null).ToList());
        }

        public ActionResult YonlendirilmisArizalar()
        {
            List<ArizaViewModel> model = new List<ArizaViewModel>();
            var userManager = MembershipTools.NewUserManager();
            new ArizaKayitRepo().GetAll().ToList()
            .ForEach(item => model.Add(new ArizaViewModel()
            {
                ArizaId=item.ID,
                UyeId = item.Uye.Id,
                UyeAdı = MembershipTools.GetUserName(item.Uye.Id),
                Email = item.Email,
                Mesaj = item.Mesaj,
                TelNo = item.TelNo,
                TeknisyenID = item.TeknisyenID,
            }));
            var rolManager = MembershipTools.NewRoleManager();
            var roller = rolManager.Roles.ToList();
            return View(model.Where(x => x.TeknisyenID != null).ToList());
        }

        public ActionResult Detaylar(int? id)
        {
            if (id == null)
                return RedirectToAction("Anasayfa");
            var listelenecek = new ArizaKayitRepo().GetById(id.Value);
            if (listelenecek == null)
                return RedirectToAction("Anasayfa");
            var model = new ArizaViewModel()
            {
               UyeId=listelenecek.UyeId,
               UyeAdı=listelenecek.Uye.Ad+" "+listelenecek.Uye.Soyad,
               Email=listelenecek.Email,
               TelNo=listelenecek.TelNo,
               Mesaj=listelenecek.Mesaj,
               LocationX=listelenecek.LocationX,
               LocationY=listelenecek.LocationY,
               TeknisyenID=listelenecek.TeknisyenID,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Detaylar(ArizaViewModel model)
        {
            if (model == null)
                return RedirectToAction("Anasayfa");
            var ariza = new ArizaKayitRepo().GetById(model.ArizaId);
            if (ariza == null)
                return RedirectToAction("Anasayfa");
            ariza.TeknisyenID = model.TeknisyenID == 0 ? null : model.TeknisyenID;
            new ArizaKayitRepo().Update();
            return View();
        }
        #region Partials
        public PartialViewResult NavResult()
        {

            return PartialView("_PartialAdminNav");
        }

        #endregion
    }
}