using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Profiles.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for profile ownership and profile update rules.
/// </summary>
public static class ProfileErrors
{
    /// <summary>The requested profile does not exist.</summary>
    public static readonly Error ProfileNotFound = new("Profiles.ProfileNotFound", "The specified profile was not found.");
    /// <summary>The profile payload cannot create or update a valid profile.</summary>
    public static readonly Error InvalidProfileData = new("Profiles.InvalidProfileData", "Invalid profile data provided.");
}
