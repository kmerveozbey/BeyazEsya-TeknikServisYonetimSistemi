using System.Web.Mvc;

namespace TeknikServis.MVC.Areas.ServisYonetim
{
    public class ServisYonetimAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ServisYonetim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ServisYonetim_default",
                "ServisYonetim/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}