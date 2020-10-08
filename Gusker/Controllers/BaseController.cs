using Gusker.Business.DependencyInjection;
using Gusker.Business.Dto;
using Gusker.Business.Dto.Navigation;
using Gusker.Config;
using Gusker.Models;
using Gusker.Models.Shared;
using System.Configuration;
using System.Web.Mvc;

namespace Gusker.Controllers
{
    public class BaseController : Controller
    {
        protected IBusinessDependencies Dependencies { get; }
        protected BaseController(IBusinessDependencies dependencies)
        {
            Dependencies = dependencies;
        }
        public PageViewModel GetPageViewModel(
            MetadataDto metadata,
            LinkMenuDto breadcrumb = null
            )
        {
            var model = new PageViewModel();
            return InitPageViewModel(model, metadata, breadcrumb);
        }

        public PageViewModel<TViewModel> GetPageViewModel<TViewModel>(
            TViewModel data,
            MetadataDto metadata,
            LinkMenuDto breadcrumb
            ) where TViewModel : IViewModel
        {
            var model = new PageViewModel<TViewModel>()
            {
                Data = data
            };
            return (PageViewModel<TViewModel>)InitPageViewModel(model, metadata, breadcrumb);
        }

        private PageViewModel InitPageViewModel(PageViewModel model,
            MetadataDto metadata, LinkMenuDto breadcrumb)
        {
            model.Head = new HeadViewModel
            {
                Metadata = metadata ?? new MetadataDto(),
                MapsApiKey = ConfigurationManager.AppSettings[AppConfig.MapsApiKeySettingKey],
                GoogleTagManagerID = ConfigurationManager.AppSettings[AppConfig.GoogleTagManagerIDSettingKey]
            };
            model.TopMenu = Dependencies.NavigationRepository.GetTopNavigation();
            model.FooterMenu = Dependencies.NavigationRepository.GetMainNavigation();
            model.Breadcrumb = breadcrumb;

            return model;
        }
    }
}