﻿namespace ToDo.Domain.Enums;

public enum ErrorType
{
    None,
    NotFound,
    Conflict,
    Validation,
    Unauthorized,
    Forbidden,
    BadRequest,
    InternalServerError,
    ServiceUnavailable,
    TooManyRequests,
    UnProcessableEntity
}
