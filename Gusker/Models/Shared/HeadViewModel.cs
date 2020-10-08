using Gusker.Business.Dto;

namespace Gusker.Models.Shared
{
    public class HeadViewModel : IViewModel
    {
        public MetadataDto Metadata { get; set; }

        public string MapsApiKey { get; set; }

        public string GoogleTagManagerID { get; set; }
    }
}