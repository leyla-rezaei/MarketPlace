namespace MarketPlace.Application.Response;

public enum ResponseStatus
{
    Failed,
    Success,
    NotFound,
    Undefined,
    ServerError,
    UnknownError,
    UserAlreadyAdded,
    ValidationFailed,
    NotAllowed,

    //authentication
    UserAlreadyRegistered,
    UserNameNotFound,
    UserNotFound,
    UserLockedOut,
    UserNameOrPasswordIsInCorrect,
    OtpTokenIsExpiredOrInvaidToken,
    SettingPhoneConfimationToTrueFailed,

    //store
    StoreNotFound,
    UserIsNotStorOwner,

    //content 
    ContentNotAllowed,
    ContentNeedReview,

    //product
    DownloadableFileRequired,

    //product category
    CategoryNotAvailable,

    //tag category
    TagNotAvailable
}