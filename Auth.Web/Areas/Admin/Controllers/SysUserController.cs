using Auth.Common;
using Auth.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Web.Areas.Admin.Controllers
{
    public class SysUserController : Controller
    {
        private readonly ISysUserService _userService;
        public SysUserController(ISysUserService service)
        {
            _userService = service;
        }


        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Search(PageQuery query)
        {
            var result = _userService.Search(query);
            return new JsonResult()
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}