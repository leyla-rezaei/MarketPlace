using MarketPlace.Domain.Entities.Products;

namespace MarketPlace.Domain.Entities.Comments;

public class ProductComment : Comment
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public bool IsBuyer { get; set; }
}
