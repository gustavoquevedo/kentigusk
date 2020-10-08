using DynamicRouting;
using Gusker.Business.DependencyInjection;
using Gusker.Business.Repository.Article;
using Gusker.Models.Article;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gusker.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleController(
            IBusinessDependencies dependencies,
            IArticleRepository articleRepository
            ) : base(dependencies)
        {
            _articleRepository = articleRepository;
        }

        public ActionResult Index()
        {
            var node = DynamicRouteHelper.GetPage();

            var articlesSection = _articleRepository.GetArticles(node.NodeAliasPath);
            var sectionViewModel = new ArticlesSectionViewModel
            {
                Name = articlesSection.Name,
                Articles = articlesSection.Articles.Select(a => new ArticleViewModel
                { 
                    Title = a.Title,
                    Subtitle = a.Subtitle,
                    Url = a.Url
                })
            };

            var model = GetPageViewModel(
                sectionViewModel,
                articlesSection.Metadata,
                articlesSection.Breadcrumb);

            return View(model);
        }

        public ActionResult Details()
        {
            var page = DynamicRouteHelper.GetPage();

            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentID);

            var article = _articleRepository.GetArticle(page.NodeGUID);

            if (article == null)
            {
                throw new HttpException(404, "Article not found");
            }

            var articleViewModel = new ArticleViewModel
            {
                Title = article.Title,
                Subtitle = article.Subtitle
            };

            var model = GetPageViewModel(
                articleViewModel,
                article.Metadata,
                article.Breadcrumb);

            return View(model);
        }
    }
}