using CMS.DocumentEngine;
using DynamicRouting;
using Gusker.Business.DependencyInjection;
using Gusker.Business.Repository.DefaultPage;
using Gusker.Models;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using System.Linq;
using System.Web.Mvc;

namespace Gusker.Controllers
{
    public class DefaultPageController : BaseController
    {
        private readonly IDefaultPageRepository _pageRepository;

        public DefaultPageController(
            IBusinessDependencies dependencies,
            IDefaultPageRepository pageRepository
            ) : base(dependencies)
        {
            _pageRepository = pageRepository;
        }

        public ActionResult Home()
        {
            return Index("/Home");
        }

        public ActionResult Index(string absolutePath = "")
        {
            var node = (TreeNode)DynamicRouteHelper.GetPage(absolutePath);

            HttpContext.Kentico().PageBuilder().Initialize(node.DocumentID);

            var page = _pageRepository.GetPage(node.NodeGUID);

            if (page.RedirectToFirstChild && node.Children.Any())
            {
                return Redirect(node.Children.FirstItem.RelativeURL);
            }
            else if (!string.IsNullOrWhiteSpace(page.RedirectToUrl))
            {
                return Redirect(page.RedirectToUrl);
            }

            var defaulPageViewModel = new DefaultPageViewModel
            {
                Title = page.PageTitle                
            };
            
            var model = GetPageViewModel(
                defaulPageViewModel,
                page.Metadata,
                page.Breadcrumb);

            return View(nameof(Index), model);
        }
    }
}