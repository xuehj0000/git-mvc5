using Auth.DAL;
using Auth.Web.Filter;
using FluentNHibernate.Automapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Auth.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());  // ��mvc �������һ������������
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile(new AutoMapperConfig());
            });
        }
    }
}
