using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.BLL.Repository;
using TeknikServis.BLL.Settings;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.ViewModels;

namespace TeknikServis.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult ArizaTakip()
        {
            List<ArizaViewModel> model = new List<ArizaViewModel>();
            var userID = User.Identity.GetUserId();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                new ArizaKayitRepo().GetAll().ToList()
                    .ForEach(item => model.Add(new ArizaViewModel()
                    {
                        UyeId = userID,
                        Email = item.Email,
                        TelNo = item.TelNo,
                        //TeknisyenID=item.Teknisyen.Uye.Id,
                        Mesaj = item.Mesaj,
                    }));
            }
            return View(model.Where(x => x.UyeId == userID).ToList());
        }



        public ActionResult ArizaKayit()
        {
            //var userID = User.Identity.GetUserId();
            return View();
        }
        //[Authorize] = IsAuthenticated yerine bunu kullanabilirsin diye biliyorum
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ArizaKayit(ArizaViewModel model)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Anasayfa", "Home");
            }
            try
            {
                var userID = User.Identity.GetUserId();

                ArizaKayit yeniAriza = new ArizaKayit()
                {
                    UyeId = User.Identity.GetUserId(),
                    TeknisyenID = null,
                    LocationX = model.LocationX,
                    LocationY = model.LocationY,
                    Email = model.Email,
                    TelNo = model.TelNo,
                    Mesaj = model.Mesaj,
                };
                new ArizaKayitRepo().Insert(yeniAriza);
                if (model.Dosyalar.Any())
                {
                    foreach (var dosya in model.Dosyalar)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
                        string extName = Path.GetExtension(dosya.FileName);
                        fileName = SiteSettings.UrlFormatConverter(fileName);
                        fileName += Guid.NewGuid().ToString().Replace("-", "");
                        var directoryPath = Server.MapPath("~/Uploads/arizalar");
                        var filePath = Server.MapPath("~/Uploads/arizalar/") + fileName + extName;
                        if (!Directory.Exists(directoryPath))
                            Directory.CreateDirectory(directoryPath);
                        dosya.SaveAs(filePath);
                        ResimBoyutlandir(400, 300, filePath);
                        new DosyaRepo().Insert(new Dosya()
                        {
                            DosyaYolu = @"/Uploads/arizalar/" + fileName + extName,
                            ArizaID = yeniAriza.ID,
                            Uzanti = extName.Substring(1)
                        });
                    }
                }
                return RedirectToAction("Anasayfa", "Home");

            }
            catch (Exception )
            {
                return View();
            }
        }

        [NonAction] // Merve sanki [NonAction]'a gerek yok ama sen bilirsin tabi
        public void ResimBoyutlandir(int en, int boy, string yol)
        {
            WebImage img = new WebImage(yol);
            img.Resize(en, boy, false);
            img.AddTextWatermark("ÖZBEY TEKNİK SERVİS", fontColor: "Tomato", fontSize: 18, fontFamily: "Verdana");
            img.Save(yol);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ArizaKayit(ArizaViewModel model)
        //{
        //    if (model == null)
        //        return RedirectToAction("Ekle");
        //    var yeniUrun = new ArizaKayit()
        //    {

        //    };
        //    try
        //    {
        // new UrunRepo().Insert(yeniUrun);
        //if (model.Dosyalar.Any())
        //{
        //    foreach (var dosya in model.Dosyalar)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(dosya.FileName);
        //        string extName = Path.GetExtension(dosya.FileName);
        //        fileName = SiteSettings.UrlFormatConverter(fileName);
        //        fileName += Guid.NewGuid().ToString().Replace("-", "");
        //        var directoryPath = Server.MapPath("~/Uploads/products");
        //        var filePath = Server.MapPath("~/Uploads/products/") + fileName + extName;
        //        if (!Directory.Exists(directoryPath))
        //            Directory.CreateDirectory(directoryPath);
        //        dosya.SaveAs(filePath);
        //        ResimBoyutlandir(400, 300, filePath);
        //        await new DosyaRepo().Insert(new Dosya()
        //        {
        //            DosyaYolu = @"/Uploads/products/" + fileName + extName,
        //            AktifMi = true,
        //            UrunId = yeniUrun.Id,
        //            Uzanti = extName.Substring(1)
        //        });
        //    }
        //}
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return RedirectToAction("Ekle");
        //    }
        //}



        public ActionResult KayitOl()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        #region Partials
        public PartialViewResult HeaderResult()
        {

            return PartialView("_PartialHeader");
        }
        public PartialViewResult NavResult()
        {

            return PartialView("_PartialNav");
        }
        public PartialViewResult SectionResult()
        {

            return PartialView("_PartialSection");
        }
        public PartialViewResult FeaturesResult()
        {

            return PartialView("_PartialFeatures");
        }
        public PartialViewResult SubscribeResult()
        {
            return PartialView("_PartialSubscribe");
        }
        public PartialViewResult FooterResult()
        {
            return PartialView("_PartialFooter");
        }
        #endregion

    }
}