using CMS.DocumentEngine;
using Gusker.Business.Dto.Navigation;
using System.Linq;

namespace Gusker.Business.Service.Navigation
{
    public class NavigationService : INavigationService
    {
        #region Breadcrumb

        public LinkMenuDto GetBreadcrumb(TreeNode treeNode)
        {
            switch (treeNode.NodeClassName)
            {
                //case "Gusker.Article":
                //    break;
                default:
                    return BuildBreadcrumbContentPage(treeNode);
            }
        }

        private LinkMenuDto BuildBreadcrumbContentPage(TreeNode treeNode)
        {
            var breadcrumb = new LinkMenuDto
            {
                MenuItems = treeNode.DocumentsOnPath
                        .Select(tn => new LinkDto
                        {
                            Url = tn.NodeAliasPath.ToLower(),
                            Text = tn.DocumentName
                        })
                        .ToList()
            };
            return UpdateBreadcrumbRootAndTail(breadcrumb);
        }

        private static LinkMenuDto UpdateBreadcrumbRootAndTail(LinkMenuDto breadcrumb)
        {
            if (breadcrumb.MenuItems.Any())
            {
                breadcrumb.MenuItems.First().Text = "Home";
                breadcrumb.MenuItems.First().Url = "/";
            }
            return breadcrumb;
        }

        #endregion
    }
}