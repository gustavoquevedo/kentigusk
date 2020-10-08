namespace Gusker.Business.Dto
{
    public class MetadataDto : IDto
    {
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

        public bool AnyEmptyValue =>
            string.IsNullOrWhiteSpace(MetaTitle) ||
            string.IsNullOrWhiteSpace(MetaDescription) ||
            string.IsNullOrWhiteSpace(MetaKeywords);
    }
}