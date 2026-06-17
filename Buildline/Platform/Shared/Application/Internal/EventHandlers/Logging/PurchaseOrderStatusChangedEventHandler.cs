using Buildline.Platform.Procurement.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a purchase order status is changed.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     The handler records the identifier and the previous and current status to provide an audit
///     trail for procurement lifecycle changes.
/// </remarks>
public class PurchaseOrderStatusChangedEventHandler(ILogger<PurchaseOrderStatusChangedEventHandler> logger)
    : IEventHandler<PurchaseOrderStatusChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(PurchaseOrderStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Purchase order {PurchaseOrderId} status changed from {PreviousStatus} to {CurrentStatus}.",
            notification.PurchaseOrderId, notification.PreviousStatus, notification.CurrentStatus);
        return Task.CompletedTask;
    }
}
