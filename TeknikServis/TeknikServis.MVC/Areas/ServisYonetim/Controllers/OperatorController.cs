using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.BLL.Repository;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Entity.ViewModels;

namespace TeknikServis.MVC.Areas.ServisYonetim.Controllers
{
    [Authorize(Roles = "Admin,Operator")]
    public class OperatorController : Controller
    {
        // GET: ServisYonetim/Operator
        public ActionResult Anasayfa()
        {
            return View();
        }
        List<TeknisyenViewModel> model = new List<TeknisyenViewModel>();

        public void Kullanicilar()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.IsInRole("Operator"))
                {

                    var userManager = MembershipTools.NewUserManager();
                    userManager.Users.ToList()
                        .ForEach(item => model.Add(new TeknisyenViewModel()
                        {
                            UyeID = item.Id,
                            Email = item.Email,
                            Ad = item.Ad,
                            Soyad = item.Soyad,
                            KullaniciAdi=item.UserName,
                            BostaMi=item.Teknisyenler.Select(x=>x.BostaMi).FirstOrDefault(),
                        }));
                }
            }
        }
        public ActionResult TeknisyenIslemleri()
        {

            var rolManager = MembershipTools.NewRoleManager();
            var rol = rolManager.Roles.Where(x => x.Name == "Teknisyen").Select(x => x.Id).FirstOrDefault();
            var roller = rolManager.Roles.ToList();
            Kullanicilar();
            return View(model.Where(x => x.BostaMi == true && x.RolID==rol).ToList());
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
                TelNo = item.TelNo,
                TeknisyenID = item.TeknisyenID,
            }));
            var rolManager = MembershipTools.NewRoleManager();
            var roller = rolManager.Roles.ToList();
            return View(model.Where(x => x.TeknisyenID == null).ToList());
        }
        public ActionResult YonlendirilmisArizalar()
        {
            List<ArizaViewModel> model = new List<ArizaViewModel>();
            var userManager = MembershipTools.NewUserManager();
            new ArizaKayitRepo().GetAll().ToList()
            .ForEach(item => model.Add(new ArizaViewModel()
            {
                ArizaId = item.ID,
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
                UyeId = listelenecek.UyeId,
                UyeAdı = listelenecek.Uye.Ad + " " + listelenecek.Uye.Soyad,
                Email = listelenecek.Email,
                TelNo = listelenecek.TelNo,
                Mesaj = listelenecek.Mesaj,
                LocationX = listelenecek.LocationX,
                LocationY = listelenecek.LocationY,
                TeknisyenID = listelenecek.TeknisyenID,
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

            return PartialView("_PartialOperatorNav");
        }
        #endregion
    }
}