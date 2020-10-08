using Gusker.Business.Dto.Article;
using System;

namespace Gusker.Business.Repository.Article
{
    public interface IArticleRepository : IRepository
    {
        ArticleDto GetArticle(Guid nodeGuid);
        ArticleDto GetArticle(string pageAlias);
        ArticlesSectionDto GetArticles(string sectionPath);
    }
}