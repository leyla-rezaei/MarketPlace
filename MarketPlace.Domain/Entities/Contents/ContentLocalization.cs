using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Domain.Entities.Contents
{
    public abstract class ContentLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

    }
}