using MarketPlace.Dto.Media;

namespace MarketPlace.Dto.StoretSettings
{
    public class CreateStoreResponseDto
    {
        public Guid Id { get; set; }
        public MultiMediaFileRequestDto FileInput { get; set; }
        public StoreRequestDto StoreInput { get; set; }
    }
}