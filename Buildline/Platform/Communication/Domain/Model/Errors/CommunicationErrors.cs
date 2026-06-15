using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Communication.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for inbox message workflows.
/// </summary>
public static class CommunicationErrors
{
    /// <summary>The requested message does not exist.</summary>
    public static readonly Error MessageNotFound = new("Communication.MessageNotFound", "The specified message was not found.");
    /// <summary>The message payload is incomplete or invalid.</summary>
    public static readonly Error InvalidMessageData = new("Communication.InvalidMessageData", "Invalid message data provided.");
}
