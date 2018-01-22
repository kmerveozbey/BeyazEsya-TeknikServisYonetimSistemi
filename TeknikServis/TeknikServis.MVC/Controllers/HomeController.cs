using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ArizaKayit()
        {
            return View();
        }
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