using Gusker.Business.Repository.Navigation;
using Gusker.Business.Services.Context;

namespace Gusker.Business.DependencyInjection
{
    public interface IBusinessDependencies
    {
        ISiteContextService SiteContextService { get; }
        INavigationRepository NavigationRepository { get; }
    }
}
