using bundleLook.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using bundleLook.Models;

namespace bundleLook.Controllers
{
    //[Localization("en")]
    public class HomeController : Controller
    {
        MultilingualEntities db = new MultilingualEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var Lang = Request.RequestContext.RouteData.Values["lang"];

            ViewBag.News = db.News.Where(n=>n.Language==Lang);
            return View();
        }

        public ActionResult Contact()
        {
            var BrouserH = Request.Browser.ScreenPixelsHeight;
            var BrouserW = Request.Browser.ScreenPixelsWidth;
            var BrouserD = Request.UserLanguages[0];

            ViewBag.Us = BrouserH + " "+ BrouserW+" "+ BrouserD;

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}