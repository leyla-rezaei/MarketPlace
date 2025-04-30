using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Posts
{
    [Table(nameof(PostLocalization), Schema = nameof(SchemaConsts.localization))]
    public class PostLocalization : BaseLocalization
    {
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// tags seperate by |
        /// </summary>
        public string Tags { get; set; } = string.Empty;

        public Guid PostId {  get; set; }
        public Post Post { get; set; }
    }
}
