using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.Common;
using MarketPlace.Domain.Entities.Orders.Invoices;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Orders.ShoppingCards;

[Table(nameof(ShoppingCard), Schema = nameof(SchemaConsts.order))]
public class ShoppingCard : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public bool IsOpen { get; set; }

    #region Navigation properties
    //TODO make this relation one to many
    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<ShoppingCardDetail> ShoppingCardDetails { get; set; }
    #endregion
}
