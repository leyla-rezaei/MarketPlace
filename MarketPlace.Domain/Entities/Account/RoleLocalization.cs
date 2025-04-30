using MarketPlace.Domain.Entities.Common;
using MarketPlace.Infrastructure.Identity.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Account
{
    [Table(nameof(RoleLocalization), Schema = nameof(SchemaConsts.localization))]
    public class RoleLocalization :BaseLocalization
    {
        public string Description { get; set; } = string.Empty;
        public Guid RoleId { get; set; } 
        public Role Role {  get; set; }
    }
}