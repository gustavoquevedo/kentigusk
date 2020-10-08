namespace Gusker.Business.Dto.Navigation
{
    public class LinkDto : IDto
    {
        public string Text { get; set; }

        public string Url { get; set; }

        public bool Disabled { get; set; }

        public bool Active { get; set; }

        public bool Hidden { get; set; }

        public bool OpenInNewTab { get; set; }
    }
}