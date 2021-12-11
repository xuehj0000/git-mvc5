using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Web.Areas.Admin.Controllers
{
    public class SysMenuController : Controller
    {
        // GET: Admin/SysMenu
        public ActionResult Index()
        {
            return View();
        }
    }
}