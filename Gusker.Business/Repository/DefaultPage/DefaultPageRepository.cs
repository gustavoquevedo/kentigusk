using Gusker.Business.Dto;
using Gusker.Business.Dto.DefaultPage;
using Gusker.Business.Service.Metadata;
using Gusker.Business.Service.Navigation;
using Gusker.Business.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using DefaultPageType = CMS.DocumentEngine.Types.Gusker.DefaultPage;

namespace Gusker.Business.Repository.DefaultPage
{
    public class DefaultPageRepository : BasePageRepository, IDefaultPageRepository
    {

        private readonly string[] _pageColumns =
        {
            "Name", "PageTitle", "RedirectToFirstChild", "RedirectToUrl"
        };

        private Func<DefaultPageType, DefaultPageDto> pageDtoSelect => page =>
        {
            var dto = new DefaultPageDto()
            {
                Name = page.Name,
                PageTitle = page.PageTitle,
                NodeAliasPath = page.NodeAliasPath,
                RedirectToFirstChild = page.RedirectToFirstChild,
                RedirectToUrl = page.RedirectToUrl,
                Metadata = new MetadataDto
                {
                    MetaTitle = page.DocumentPageTitle,
                    MetaDescription = page.DocumentPageDescription,
                    MetaKeywords = page.DocumentPageKeyWords
                },
                Breadcrumb = GetBreadcrumb(page)
            };
            if (string.IsNullOrWhiteSpace(dto.PageTitle))
            {
                dto.PageTitle = page.Name;
            }
            return _metadataService.CheckInheritedMetadata(dto, page);
        };


        public DefaultPageRepository(
            IDocumentQueryService documentQueryService,
            INavigationService navigationService,
            IMetadataService metadataService
            ) : base(documentQueryService, navigationService, metadataService)
        {
        }

        public DefaultPageDto GetPage(Guid guid)
        {
            return DocumentQueryService.GetDocument<DefaultPageType>(guid)
                .AddColumns(_pageColumns.Concat(BasePageColumns))
                .WhereEquals("NodeGUID", guid)
                .ToList()
                .Select(pageDtoSelect)
                .FirstOrDefault();
        }

        public IEnumerable<DefaultPageDto> GetPages()
        {
            return DocumentQueryService.GetDocuments<DefaultPageType>()
                .AddColumns(_pageColumns.Concat(BasePageColumns))
                .ToList()
                .Select(pageDtoSelect);
        }
    }
}