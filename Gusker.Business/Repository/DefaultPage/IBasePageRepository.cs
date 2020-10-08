using CMS.DocumentEngine;
using Gusker.Business.Dto.Navigation;

namespace Gusker.Business.Repository.DefaultPage
{
    public interface IBasePageRepository : IRepository
    {
        LinkMenuDto GetBreadcrumb(TreeNode treeNode);
    }
}