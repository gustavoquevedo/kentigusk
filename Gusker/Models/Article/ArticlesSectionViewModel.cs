using System.Collections.Generic;

namespace Gusker.Models.Article
{
    public class ArticlesSectionViewModel : IViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}