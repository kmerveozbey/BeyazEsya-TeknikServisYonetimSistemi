using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.IdentityModels;
using TeknikServis.Entity.ViewModels;

namespace TeknikServis.MVC.Areas.ServisYonetim.Controllers
{
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


        #region Partials
        public PartialViewResult NavResult()
        {

            return PartialView("_PartialOperatorNav");
        }
        #endregion
    }
}