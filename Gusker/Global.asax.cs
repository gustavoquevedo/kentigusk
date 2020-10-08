using DynamicRouting.Kentico.MVC;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Gusker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Enables and configures selected Kentico ASP.NET MVC integration features
            ApplicationConfig.RegisterFeatures(ApplicationBuilder.Current);

            // Registers routes including system routes for enabled features
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Dependency injection
            AutofacConfig.ConfigureContainer();

            // Registers enabled bundles
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterPageTemplateFilters();
        }

        private void RegisterPageTemplateFilters()
        {
            //PageBuilderFilters.PageTemplates.Add(new MyOtherFilters());

            // Enabled, This must be last!
            PageBuilderFilters.PageTemplates.Add(new EmptyPageTemplateFilter());
            // Disabled
            // PageBuilderFilters.PageTemplates.Add(new NoEmptyPageTemplateFilter());
        }
    }
}
