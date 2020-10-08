using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Gusker;
using Gusker.Business.Dto;
using Gusker.Business.Dto.Article;
using Gusker.Business.Repository.DefaultPage;
using Gusker.Business.Service.Metadata;
using Gusker.Business.Service.Navigation;
using Gusker.Business.Services.Query;
using System;
using System.Linq;
using ArticleType = CMS.DocumentEngine.Types.Gusker.Article;

namespace Gusker.Business.Repository.Article
{
    public class ArticleRepository : BasePageRepository, IArticleRepository
    {
        private readonly string[] _articlesSectionColumns =
        {
            "Name"
        };

        private readonly string[] _articleColumns =
        {
            "Title", "Subtitle"
        };

        private Func<ArticleType, ArticleDto> ArticleDtoSelect => article =>
        {
            var dto = new ArticleDto()
            {
                Title = article.Title,
                Subtitle = article.Subtitle,
                Url = article.RelativeURL,
                Metadata = new MetadataDto
                {
                    MetaTitle = article.DocumentPageTitle,
                    MetaDescription = article.DocumentPageDescription,
                    MetaKeywords = article.DocumentPageKeyWords
                },
                DocumentId = article.DocumentID,
                Breadcrumb = GetBreadcrumb(article)
            };
            return _metadataService.CheckInheritedMetadata(dto, article);
        };
        private Func<ArticlesSection, ArticlesSectionDto> ArticlesSectionDtoSelect => articlesSection =>
        {
            var dto = new ArticlesSectionDto()
            {
                Name = articlesSection.Name,
                Metadata = new MetadataDto
                {
                    MetaTitle = articlesSection.DocumentPageTitle,
                    MetaDescription = articlesSection.DocumentPageDescription,
                    MetaKeywords = articlesSection.DocumentPageKeyWords
                },
                DocumentId = articlesSection.DocumentID,
                Breadcrumb = GetBreadcrumb(articlesSection)
            };
            return _metadataService.CheckInheritedMetadata(dto, articlesSection);
        };

        public ArticleRepository(
            IDocumentQueryService documentQueryService,
            INavigationService navigationService,
            IMetadataService metadataService
            ) : base(documentQueryService, navigationService, metadataService)
        {
        }

        public ArticleDto GetArticle(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<ArticleType>(nodeGuid)
                .AddColumns(_articleColumns.Concat(BasePageColumns))
                .Select(ArticleDtoSelect)
                .FirstOrDefault();
        }

        public ArticleDto GetArticle(string pageAlias)
        {
            return DocumentQueryService.GetDocument<ArticleType>(pageAlias)
                .AddColumns(_articleColumns.Concat(BasePageColumns))
                .ToList()
                .Select(ArticleDtoSelect)
                .FirstOrDefault();
        }

        public ArticlesSectionDto GetArticles(string sectionPath)
        {
            if (string.IsNullOrWhiteSpace(sectionPath))
            {
                return null;
            }

            var section = DocumentQueryService.GetDocuments<ArticlesSection>()
                .AddColumns(_articlesSectionColumns.Concat(BasePageColumns))
                .Path(sectionPath)
                .Select(ArticlesSectionDtoSelect)
                .FirstOrDefault();

            if (section == null)
            {
                return null;
            }

            section.Articles = DocumentQueryService.GetDocuments<ArticleType>()
                .AddColumns(_articleColumns.Concat(BasePageColumns))
                .Path(sectionPath, PathTypeEnum.Children)
                .OrderBy("NodeOrder")
                .Select(ArticleDtoSelect)
                .ToList();

            return section;
        }
    }
}