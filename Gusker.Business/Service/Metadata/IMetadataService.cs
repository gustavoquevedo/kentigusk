using CMS.DocumentEngine;
using Gusker.Business.Dto;
using Gusker.Business.Services;

namespace Gusker.Business.Service.Metadata
{
    public interface IMetadataService : IService
    {
        TDocumentDto CheckInheritedMetadata<TDocumentDto>(TDocumentDto dto, TreeNode node) where TDocumentDto : PageWithMetadataDto;
    }
}