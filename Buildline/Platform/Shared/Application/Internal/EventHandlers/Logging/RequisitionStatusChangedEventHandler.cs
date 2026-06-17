using Buildline.Platform.Requisition.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a requisition status is changed.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     The handler records the identifier and both the previous and current status for audit
///     visibility in the application log stream.
/// </remarks>
public class RequisitionStatusChangedEventHandler(ILogger<RequisitionStatusChangedEventHandler> logger)
    : IEventHandler<RequisitionStatusChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(RequisitionStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Requisition {RequisitionId} status changed from {PreviousStatus} to {CurrentStatus}.",
            notification.RequisitionId, notification.PreviousStatus, notification.CurrentStatus);
        return Task.CompletedTask;
    }
}
