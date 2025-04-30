using MarketPlace.Domain.Entities.Comments;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Media;
using MarketPlace.Domain.Entities.Orders;
using MarketPlace.Domain.Entities.Orders.Invoices;
using MarketPlace.Domain.Entities.Orders.ShoppingCards;
using MarketPlace.Domain.Entities.StoretSettings;
using MarketPlace.Domain.Entities.StoretSettings.Selling.Promotions;
using MarketPlace.Domain.Enums.Account;
using Microsoft.AspNetCore.Identity;

namespace MarketPlace.Domain.Entities.Account;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public string? OtpToken { get; set; }
    public bool IsActive { get; set; }
    public UserNature UserNature { get; set; }

    public Guid? ProfileImageId { get; set; }
    public MultiMediaFile ProfileImage { get; set; }

    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset? ModificationDate { get; set; }
    public bool IsArchived { get; set; }


    #region Navigation properties
    public ICollection<UserBussines> UserBussines { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<OrderNote> OrderNotes { get; set; }
    public ICollection<ShoppingCard> ShoppingCards { get; set; }
    public ICollection<Store> Stores { get; set; }
    public ICollection<Coupon> Coupons { get; set; }
    public ICollection<UserLocalization> Localizations { get; set; }
    #endregion
}
 