using System.Collections.Generic;

namespace Gusker.Business.Dto.Article
{
    public class ArticlesSectionDto : BasePageDto
    {
        public string Name { get; set; }

        public IEnumerable<ArticleDto> Articles { get; set; }
    }
}