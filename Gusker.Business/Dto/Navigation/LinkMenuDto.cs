using System.Collections.Generic;

namespace Gusker.Business.Dto.Navigation
{
    public class LinkMenuDto : IDto
    {
        public LinkDto Parent { get; set; }

        public IEnumerable<LinkDto> MenuItems { get; set; }
    }
}
