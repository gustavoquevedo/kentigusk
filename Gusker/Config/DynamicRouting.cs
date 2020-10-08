using CMS.DocumentEngine.Types.CMS;
using CMS.DocumentEngine.Types.Gusker;
using DynamicRouting.Kentico.MVC;
using Gusker.Controllers;

[assembly: DynamicRouting(typeof(DefaultPageController), new string[] { Root.CLASS_NAME }, nameof(DefaultPageController.Home))]
[assembly: DynamicRouting(typeof(ArticleController), new string[] { ArticlesSection.CLASS_NAME }, nameof(ArticleController.Index))]
[assembly: DynamicRouting(typeof(ArticleController), new string[] { Article.CLASS_NAME }, nameof(ArticleController.Details))]
[assembly: DynamicRouting(typeof(DefaultPageController), new string[] { DefaultPage.CLASS_NAME }, nameof(DefaultPageController.Index))]
[assembly: DynamicRouting("~/Views/Contact/Details.cshtml", typeof(Contact), Contact.CLASS_NAME)]