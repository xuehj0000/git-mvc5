using Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Web.Filter
{
    public class CrumbsActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var url = filterContext.HttpContext.Request.Url.AbsoluteUri;
            Uri uri = new Uri(url);
            var query = uri.Query;
            var crumbs = UriHelper.GetUrlParameterValue(query, "crumbId");
            crumbs = HttpContext.Current.Server.UrlDecode(crumbs);
            filterContext.HttpContext.Session[CacheConstant.CacheCurrentCrumbs()] = null;
            if (!string.IsNullOrEmpty(crumbs))
            {
                var crumbsList = crumbs.Split('_').Select(r => r.Trim()).ToList();
                filterContext.HttpContext.Session[CacheConstant.CacheCurrentCrumbs()] = crumbsList;
            }
            //base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}