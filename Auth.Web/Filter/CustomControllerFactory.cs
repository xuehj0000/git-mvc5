using System;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Auth.Web.Filter
{
    /// <summary>
    /// 控制器工厂
    /// </summary>
    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IUnityContainer container = CustomMyFactory.GetContainer();
            object instance = container.Resolve(controllerType);
            return (IController)instance;
        }
    }
}