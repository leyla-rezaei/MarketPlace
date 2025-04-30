using MarketPlace.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Entities.StoretSettings.Settings;

[Table(nameof(StoreDiscussionSetting), Schema = nameof(SchemaConsts.store_setting))]
public class StoreDiscussionSetting : BaseEntity
{
    public Guid StoreId { get; set; }
    public Store Store { get; set; }

    #region Default post settings
    public bool IsAllowLinkNotificationsFromOtherBlogs { get; set; }
    public bool IsAllowToSubmitCommentsOnNewPosts { get; set; }
    #endregion

    #region comment settings
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
    #endregion

    #region Email me whenever
    public bool IsEmailWhenNewPostCreated{ get; set; }
    public bool IsEmailWhenAnyonePostsComment { get; set; }
    public bool IsEmailWhenACommentHeldForModeration { get; set; }
    #endregion

    #region Before a comment appears
    public bool IsCommentMustManuallyApproved { get; set; }
    public bool IsCommenAuthorMustHavePreviouslyApprovedComment { get; set; }
    #endregion

    #region Comment Moderation
    public int NumberOfCharacteriseToHoldInQueue { get; set; }

    /// <summary>
    /// seperate by new line
    /// </summary>
    public string HoldQueueWords { get; set; } = string.Empty;
    /// <summary>
    /// seperate by new line
    /// </summary>
    public string DisallowedCommentKeys { get; set; } = string.Empty;

    #endregion

}
