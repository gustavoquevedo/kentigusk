using System.Collections.Generic;

namespace Gusker.Business.Dto.Navigation
{
    public class FirstLevelLinkMenuDto : IDto
    {
        public LinkDto Parent { get; set; }
        public IEnumerable<LinkMenuDto> MenuItems { get; set; }
    }
}
