using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeknikServis.MVC.Areas.ServisYonetim.Controllers
{
    [Authorize(Roles = "Teknisyen")]
    public class TeknisyenController : Controller
    {
        // GET: ServisYonetim/Teknisyen
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}