using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoShopping.Web.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            var model = UoW.Videos.Get(e => e.StartDate <= DateTime.Today &&
                e.EndDate >= DateTime.Today)
                .OrderBy(e => Guid.NewGuid()).FirstOrDefault();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}