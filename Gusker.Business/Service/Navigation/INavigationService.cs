using CMS.DocumentEngine;
using Gusker.Business.Dto.Navigation;
using Gusker.Business.Services;

namespace Gusker.Business.Service.Navigation
{
    public interface INavigationService : IService
    {
        LinkMenuDto GetBreadcrumb(TreeNode treeNode);
    }
}