using MarketPlace.Domain.Enums.MultiMediaFiles;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.Media;

[Table(nameof(MenuMultiMedia), Schema = nameof(SchemaConsts.media))]
public class MenuMultiMedia : MultiMediaFile
{
    public MenuMultiMedia()
    {
        MediaContentType = MediaContentType.Menue;

    }
    public string MenuIconUrl { get; set; }
}
