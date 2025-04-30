using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions
{
    [Table(nameof(CouponLocalization), Schema = nameof(SchemaConsts.localization))]
    public class CouponLocalization :BaseLocalization
    {
        public string Description { get; set; } = string.Empty;

        public Guid CouponId {  get; set; } 
        public Coupon Coupon { get; set; }
    }
}
