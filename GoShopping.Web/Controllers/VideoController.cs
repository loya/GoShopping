using GoShopping.Business;
using GoShopping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;

namespace GoShopping.Web.Controllers
{
    public class VideoController : BaseController
    {
        public VideoController()
        {
            UoW = new GoShoppingUow();
        }

        //
        // GET: /Video/
        public ActionResult Index()
        {
            var model = UoW.Videos.GetAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Video video)
        {
            if (ModelState.IsValid)
            {
                UoW.Videos.Add(video);
                UoW.Save();
                return RedirectToAction("Index", this.GridRouteValues());
            }
            return View("Index", UoW.Videos.GetAll());
        }

        [HttpPost]
        public ActionResult Update(Video video)
        {
            if (ModelState.IsValid)
            {
                UoW.Videos.Update(video);
                UoW.Save();
                return RedirectToAction("Index", this.GridRouteValues());
            }
            return View("Index", UoW.Videos.GetAll());
        }

        [HttpPost]
        public ActionResult Destroy(int id)
        {
            UoW.Videos.Delete(id);
            UoW.Save();
            return RedirectToAction("Index", UoW.Videos.GetAll());
        }
	}
}