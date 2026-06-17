using Buildline.Platform.Communication.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a message state is changed.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     State transitions for internal messages (read, starred) are logged to provide an audit trail
///     for the communication bounded context.
/// </remarks>
public class MessageStateChangedEventHandler(ILogger<MessageStateChangedEventHandler> logger)
    : IEventHandler<MessageStateChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(MessageStateChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Message {MessageId} read state: {PreviousReadState} -> {CurrentReadState}, starred: {PreviousStarredState} -> {CurrentStarredState}.",
            notification.MessageId, notification.PreviousReadState, notification.CurrentReadState,
            notification.PreviousStarredState, notification.CurrentStarredState);
        return Task.CompletedTask;
    }
}
