using System.Web.Mvc;

namespace TeknikServis.MVC.Areas.Teknisyen
{
    public class TeknisyenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Teknisyen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Teknisyen_default",
                "Teknisyen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}