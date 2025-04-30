using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Comments
{
    [Table(nameof(CommentLocalization), Schema = nameof(SchemaConsts.localization))]
    public class CommentLocalization : BaseLocalization
    {
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Guid CommentId {  get; set; }
        public Comment Comment {  get; set; }
    }
}
