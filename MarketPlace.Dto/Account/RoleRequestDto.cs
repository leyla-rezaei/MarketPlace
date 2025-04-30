namespace MarketPlace.Dto.Account
{
    public class RoleRequestDto
    {
        public bool IsArchived { get; set; }
        public List<RoleLocalizationDto>? Localizations { get; set; }
    }
    public class RoleLocalizationDto
    {
        public string Key { get; set; }
        public string? Description { get; set; }
    }
}