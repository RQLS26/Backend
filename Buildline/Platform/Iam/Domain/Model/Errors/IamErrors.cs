using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Iam.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for IAM authentication and user-management rules.
/// </summary>
public static class IamErrors
{
    /// <summary>Credentials do not match an active user account.</summary>
    public static readonly Error InvalidCredentials = new("Iam.InvalidCredentials", "Invalid email or password.");
    /// <summary>The requested user account does not exist.</summary>
    public static readonly Error UserNotFound = new("Iam.UserNotFound", "The specified user was not found.");
    /// <summary>The email is already assigned to another user.</summary>
    public static readonly Error EmailAlreadyTaken = new("Iam.EmailAlreadyTaken", "The specified email is already taken.");
}
