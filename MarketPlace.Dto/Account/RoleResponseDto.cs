namespace MarketPlace.Dto.Account
{
    public class RoleResponseDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ModificationDate { get; set; }
        public bool IsArchived { get; set; }
        public List<RoleLocalizationDto>? Localizations { get; set; } = new();
    }
}
