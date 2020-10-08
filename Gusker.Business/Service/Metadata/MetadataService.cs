using CMS.DocumentEngine;
using Gusker.Business.Dto;

namespace Gusker.Business.Service.Metadata
{
    public class MetadataService : IMetadataService
    {
        public TDocumentDto CheckInheritedMetadata<TDocumentDto>(TDocumentDto dto, TreeNode node) where TDocumentDto : PageWithMetadataDto
        {
            if (dto.Metadata.AnyEmptyValue)
            {
                node.LoadInheritedValues(new[] { "DocumentPageTitle", "DocumentPageDescription", "DocumentPageKeyWords" });
                dto.Metadata.MetaTitle = node.DocumentPageTitle;
                dto.Metadata.MetaDescription = node.DocumentPageDescription;
                dto.Metadata.MetaKeywords = node.DocumentPageKeyWords;
            }
            return dto;
        }
    }
}