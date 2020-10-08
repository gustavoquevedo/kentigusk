using Gusker.Business.Dto.Navigation;
using Gusker.Models.Shared;
using System.Collections.Generic;

namespace Gusker.Models
{
    public class PageViewModel : IViewModel
    {
        public HeadViewModel Head { get; set; }
        public IEnumerable<LinkDto> TopMenu { get; set; }
        public IEnumerable<LinkMenuDto> FooterMenu { get; set; }
        public LinkMenuDto Breadcrumb { get; set; }
    }

    public class PageViewModel<TViewModel> : PageViewModel where TViewModel : IViewModel
    {
        public TViewModel Data { get; set; }
    }
}
