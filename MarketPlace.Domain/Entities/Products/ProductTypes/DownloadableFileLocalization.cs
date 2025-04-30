using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Products.ProductTypes
{
    [Table(nameof(DownloadableFileLocalization), Schema = nameof(SchemaConsts.localization))]
    public class DownloadableFileLocalization : BaseLocalization
    {
        public string FileName { get; set; } = string.Empty;

        public Guid DownloadableFileId {  get; set; }
        public DownloadableFile DownloadableFile { get; set; }
    }
}
