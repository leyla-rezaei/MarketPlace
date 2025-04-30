using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media
{
    [Table(nameof(MultiMediaFileLocalization), Schema = nameof(SchemaConsts.localization))]
    public class MultiMediaFileLocalization :BaseLocalization
    {
        public string FileName { get; set; } = string.Empty;
        public Guid MultiMediaFileId {  get; set; }
        public MultiMediaFile MultiMediaFile { get; set; }
    }
}