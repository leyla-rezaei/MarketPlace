using MarketPlace.Domain.Enums.Account;

namespace MarketPlace.Dto.Account
{
    public class UserRequestDto
    {
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserNature UserNature { get; set; }
        public RoleType RoleType { get; set; }
        public Guid? ProfileImageId { get; set; }

        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ModificationDate { get; set; }
        public bool IsArchived { get; set; }
        public List<UserLocalizationDto>? Localizations { get; set; }
    }

    public class UserLocalizationDto
    {
        public string Key { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string FullName { get; set; }
    }
}