using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Account
{
    [Table(nameof(UserLocalization), Schema = nameof(SchemaConsts.localization))]
    public class UserLocalization : BaseLocalization
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
