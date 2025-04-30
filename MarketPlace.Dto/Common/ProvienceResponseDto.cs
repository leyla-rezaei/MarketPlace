using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Dto.Common
{
    public class ProvienceResponseDto
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
    }
}