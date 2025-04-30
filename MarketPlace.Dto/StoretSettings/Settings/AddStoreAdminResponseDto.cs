using MarketPlace.Domain.Entities.Account;
using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class AddStoreAdminResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
