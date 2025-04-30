using MarketPlace.Domain.Entities.StoretSettings;

namespace MarketPlace.Dto.StoretSettings.Settings
{
    public class StoreDiscussionSettingResponseDto
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public bool IsAllowLinkNotificationsFromOtherBlogs { get; set; }
        public bool IsAllowToSubmitCommentsOnNewPosts { get; set; }

        public bool IsCommentAuthorMustFillNameAndEmail { get; set; }
        public bool IsUsersMustRegisteredAndLoggedInToComment { get; set; }
        public bool IsAutomaticallyCloseCommentsOlderThan { get; set; }
        public int? CloseCommentOnPostOlderThan { get; set; }
        public bool IsEnableNestedComments { get; set; }
        public int? NestedCommentLevels { get; set; }
        public bool IsBreakCommentsIntoPages { get; set; }
        public int? NumberOfCommentsIntoPage { get; set; }

        public bool IsProductCommentAllowToRate { get; set; }
        public bool IsPostCommentAllowToRate { get; set; }

        public uint MaxRate { get; set; }

        public bool IsProductCommentAllowToAddMultiMediaFiles { get; set; }
        public uint ProductCommentMultiMediaFilesLimit { get; set; }

        public bool IsEmailWhenNewPostCreated { get; set; }
        public bool IsEmailWhenAnyonePostsComment { get; set; }
        public bool IsEmailWhenACommentHeldForModeration { get; set; }

        public bool IsCommentMustManuallyApproved { get; set; }
        public bool IsCommenAuthorMustHavePreviouslyApprovedComment { get; set; }

        public int NumberOfCharacteriseToHoldInQueue { get; set; }

        public string HoldQueueWords { get; set; }

        public string DisallowedCommentKeys { get; set; }
    }
}
