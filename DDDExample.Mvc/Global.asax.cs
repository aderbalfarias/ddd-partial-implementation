using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DDDExample.Mvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            SimpleInjectorInitializer.Initialize();     
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
