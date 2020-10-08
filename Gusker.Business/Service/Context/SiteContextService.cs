using Kentico.Content.Web.Mvc;
using Kentico.Web.Mvc;

namespace Gusker.Business.Services.Context
{
    public class SiteContextService : BaseService, ISiteContextService
    {
        public string SiteName { get; }

        public bool IsPreviewEnabled => System.Web.HttpContext.Current.Kentico().Preview().Enabled;

        public SiteContextService(string sitename)
        {
            SiteName = sitename;
        }
      
    }
}
