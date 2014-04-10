using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoShopping.Web.Controllers
{
    public class BaseController : Controller
    {
        protected GoShopping.Service.GoShoppingUow UoW { get; set; }

        protected BaseController()
        {
            UoW = new Service.GoShoppingUow();
        }
        protected override void Dispose(bool disposing)
        {
            if (UoW!=null && UoW is IDisposable)
            {
                ((IDisposable)UoW).Dispose();
                UoW = null;
            }
            base.Dispose(disposing);
        }
	}
}