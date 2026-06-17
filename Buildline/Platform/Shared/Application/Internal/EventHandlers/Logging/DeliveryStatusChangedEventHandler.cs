using Buildline.Platform.Delivery.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a delivery status is changed.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     Tracking status transitions is useful for operational dashboards and supplier follow-up
///     automation planned in downstream sprints.
/// </remarks>
public class DeliveryStatusChangedEventHandler(ILogger<DeliveryStatusChangedEventHandler> logger)
    : IEventHandler<DeliveryStatusChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(DeliveryStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Delivery {DeliveryId} ({TrackingId}) status changed from {PreviousStatus} to {CurrentStatus}.",
            notification.DeliveryId, notification.TrackingId, notification.PreviousStatus, notification.CurrentStatus);
        return Task.CompletedTask;
    }
}
