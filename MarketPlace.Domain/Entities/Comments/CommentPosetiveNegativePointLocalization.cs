using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Comments
{
    [Table(nameof(CommentPosetiveNegativePointLocalization), Schema = nameof(SchemaConsts.localization))]
    public class CommentPosetiveNegativePointLocalization :BaseLocalization
    {
        public string CommentPoint { get; set; } = string.Empty;
        public Guid CommentPosetiveNegativePointId {  get; set; }
        public CommentPosetiveNegativePoint CommentPosetiveNegativePoint {  get; set; }
    }
}
