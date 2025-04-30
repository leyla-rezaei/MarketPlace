using MarketPlace.Domain.Enums.Account;

namespace MarketPlace.Dto.Account
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string OtpToken { get; set; }
        public bool IsActive { get; set; }
        public UserNature UserNature { get; set; }

        public Guid ProfileImageId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ModificationDate { get; set; }
        public bool IsArchived { get; set; }

        public List<UserLocalizationDto>? Localizations { get; set; } = new();
    }
}
