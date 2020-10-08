namespace Gusker.Business.Dto.DefaultPage
{
    public class DefaultPageDto : BasePageDto
    {
        public string Name { get; set; }

        public string PageTitle { get; set; }

        public string NodeAliasPath { get; set; }

        public bool RedirectToFirstChild { get; set; }

        public string RedirectToUrl { get; set; }
    }
}
