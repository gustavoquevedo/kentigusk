using Gusker.Business.Dto.Navigation;

namespace Gusker.Business.Dto
{
    public class BasePageDto : PageWithMetadataDto
    {
        public int DocumentId { get; set; }
        public LinkMenuDto Breadcrumb { get; set; }
    }
}
