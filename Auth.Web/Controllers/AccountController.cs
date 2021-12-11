using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;
using Auth.Common;
using Auth.DAL;
using Auth.DAL.ViewEntitys;
using Auth.Interface;

namespace Auth.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISysUserService _userService;
        private readonly ISysMenuService _menuService;
        public AccountController(ISysUserService userService, ISysMenuService menuService)
        {
            _userService = userService;
            _menuService = menuService;
        }

        #region 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

         
        #endregion

        #region  接口

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            // 触发实体验证
            if (ModelState.IsValid)
            {
                var checkCode = HttpContext.Session["CheckCode"];
                if (checkCode == null || !checkCode.ToString().Equals(user.CheckCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    ModelState.AddModelError("CheckCode", "验证码输入错误");
                    return View();
                }
                var curUser = _userService.FindBy(user);
                if (curUser != null)
                {
                    HttpContext.Session["CurrentUser"] = curUser;

                    var tuples = new List<Tuple<string, string, string>>();
                    var menus = _menuService.GetSubMenu(curUser.Id, out tuples);

                    curUser.CurrentMenu = menus;


                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("failed", "用户名或者密码错误！");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        public void VerifyCode()
        {
            var code = "";
            Bitmap bitmap = VerifyCodeHelper.CreateVerifyCode(out code);
            HttpContext.Session["CheckCode"] = code;
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);
            Response.ContentType = "image/git";
        }

        [HttpPost]
        public ActionResult Register(RegisterUser register)
        {
            // 触发实体验证
            if (ModelState.IsValid)
            {
                if (!string.Equals(register.Password, register.NewPassword, StringComparison.Ordinal))
                {
                    ModelState.AddModelError("NewPassword", "两次输入的密码不一致");
                    return View(register);
                }

                if(_userService.Exist(r=>r.Name == register.Name))
                {
                    ModelState.AddModelError("Name", "用户名已存在");
                    return View(register);
                }

                if (_userService.Register(register))
                {
                    return View("Login", new LoginUser { Name = register.Name });
                }
            }
            return View(register);
        }

        public ActionResult LoginOut()
        {
            HttpContext.Session.Clear();
            return base.Redirect("/Account/Login");
        }
        #endregion



    }
}