using MarketPlace.Domain.Entities.Common;


namespace MarketPlace.Domain.Entities.StoretSettings
{
    public class StoreLocalization : BaseLocalization
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid StoreId {  get; set; }
        public Store Store {  get; set; }

    }
}
