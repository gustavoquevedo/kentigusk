using Gusker.Business.Dto.Navigation;
using System.Collections.Generic;

namespace Gusker.Business.Repository.Navigation
{
    public interface INavigationRepository
    {
        IEnumerable<LinkDto> GetTopNavigation();
        IEnumerable<LinkMenuDto> GetMainNavigation();
    }
}