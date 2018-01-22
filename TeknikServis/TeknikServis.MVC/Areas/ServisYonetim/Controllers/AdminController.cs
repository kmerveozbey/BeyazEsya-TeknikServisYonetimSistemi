using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeknikServis.BLL.Account;
using TeknikServis.DAL;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.MVC.Areas.ServisYonetim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult MusteriIslemleri(UserManager<ApplicationUser> manager)
        {
           MyContext UsersContext = new MyContext();
            return View(UsersContext.Users.ToList());
        }

        public ActionResult OperatorIslemleri()
        {
            return View();
        }

        public ActionResult TeknisyenIslemleri()
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