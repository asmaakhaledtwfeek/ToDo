using ToDo.Domain.Enums;
using ToDo.Domain.Resources;

namespace ToDo.Domain.Shared;

public record Error(string Code, ErrorType Type, string Description = "")
{
    public static readonly Error None = new(Message.Application_Success, ErrorType.None);

    public static Error CreateError(ErrorType errorType, string code)
    {
        return new Error(code, errorType);
    }

    public static Error NotFound() =>
        new Error(Message.Application_NotFound, ErrorType.NotFound);

    public static Error Conflict() =>
        new Error(Message.Application_Conflict, ErrorType.Conflict);

    public static Error Validation() =>
        new Error(Message.Application_Validation, ErrorType.Validation);

    public static Error Unauthorized() =>
        new Error(Message.Application_Unauthorized, ErrorType.Unauthorized);

    public static Error Forbidden() =>
        new Error(Message.Application_Forbidden, ErrorType.Forbidden);

    public static Error BadRequest() =>
        new Error(Message.Application_BadRequest, ErrorType.BadRequest);

    public static Error InternalServerError() =>
        new Error(Message.Application_InternalServerError, ErrorType.InternalServerError);

    public static Error ServiceUnavailable() =>
        new Error(Message.Application_ServiceUnavailable, ErrorType.ServiceUnavailable);

    public static Error TooManyRequests() =>
        new Error(Message.Application_TooManyRequests, ErrorType.TooManyRequests);

    public static Error UnProcessableEntity() =>
        new Error(Message.Application_UnProcessableEntity, ErrorType.UnProcessableEntity);
}
