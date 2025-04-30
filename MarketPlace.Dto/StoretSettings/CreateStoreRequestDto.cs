using MarketPlace.Dto.Media;

namespace MarketPlace.Dto.StoretSettings
{
    public class CreateStoreRequestDto
    {
        public MultiMediaFileRequestDto FileInput { get; set; }
        public StoreRequestDto StoreInput { get; set; }
    }
}
