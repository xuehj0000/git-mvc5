using System;
using System.Web.Mvc;
using Auth.Common;
using Auth.Interface;
using Auth.Web.Filter;


namespace Auth.Web.Areas.Admin.Controllers
{
    public class SysUserController : Controller
    {
        private readonly ISysUserService _userService;
        public SysUserController(ISysUserService service)
        {
            _userService = service;
        }


        [CrumbsActionFilterAttribute]
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