using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Enums.Selling;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Setting;

[Table(nameof(StoreGeneralSellingSettings), Schema = nameof(SchemaConsts.selling_setting) )]
public class StoreGeneralSellingSettings : BaseEntity
{
    //TODO only one setting per store
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; }

    public WeightUnit WeightUnit { get; set; }
    public DimensionsUnit DimensionsUnit { get; set; }

    public bool IsEnableStarRatingOnProductReviews { get; set; }
    public bool IsProductStarRatingsRequired { get; set; }
}
