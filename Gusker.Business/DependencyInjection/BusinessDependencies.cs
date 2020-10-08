using Gusker.Business.Repository.Navigation;
using Gusker.Business.Service.Navigation;
using Gusker.Business.Services.Context;

namespace Gusker.Business.DependencyInjection
{
    public class BusinessDependencies : IBusinessDependencies
    {
        public ISiteContextService SiteContextService { get; }
        public INavigationService NavigationService { get; }
        public INavigationRepository NavigationRepository { get; }

        public BusinessDependencies(
            ISiteContextService siteContextService,
            INavigationService navigationService,
            INavigationRepository navigationRepository
            )
        {
            SiteContextService = siteContextService;
            NavigationService = navigationService;
            NavigationRepository = navigationRepository;
        }
    }
}
