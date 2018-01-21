using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeknikServis.MVC.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Anasayfa()
        {
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