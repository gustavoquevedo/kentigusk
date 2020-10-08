using CMS.DocumentEngine;
using Gusker.Business.Dto.Navigation;
using Gusker.Business.Service.Metadata;
using Gusker.Business.Service.Navigation;
using Gusker.Business.Services.Query;

namespace Gusker.Business.Repository.DefaultPage
{
    public class BasePageRepository : BaseRepository, IBasePageRepository
    {
        protected readonly INavigationService _navigationService;
        protected readonly IMetadataService _metadataService;

        protected readonly string[] BasePageColumns = 
        {
            "DocumentPageTitle", "DocumentPageDescription", "DocumentPageKeyWords",
            "NodeGUID", "NodeAlias", "NodeAliasPath", "NodeSiteID", "DocumentCulture"
        };

        protected BasePageRepository(
            IDocumentQueryService documentQueryService,
            INavigationService navigationService,
            IMetadataService metadataService
            ) : base(documentQueryService)
        {
            _navigationService = navigationService;
            _metadataService = metadataService;
        }

        public LinkMenuDto GetBreadcrumb(TreeNode treeNode)
        {
            return _navigationService.GetBreadcrumb(treeNode);
        }
    }
}