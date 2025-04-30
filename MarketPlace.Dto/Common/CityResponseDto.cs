using MarketPlace.Domain.Entities.Common;

namespace MarketPlace.Dto.Common
{
    public class CityResponseDto
    {
        public Guid CountryStateId { get; set; }
        public Provience CountryState { get; set; }
        public string Name { get; set; }

    }
}
