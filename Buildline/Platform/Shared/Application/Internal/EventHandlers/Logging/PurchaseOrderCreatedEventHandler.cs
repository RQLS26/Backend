using Buildline.Platform.Procurement.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a purchase order is created.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     This handler is the foundation for automated inventory reservation or supplier notification
///     once cross-context integration is added to the architecture.
/// </remarks>
public class PurchaseOrderCreatedEventHandler(ILogger<PurchaseOrderCreatedEventHandler> logger)
    : IEventHandler<PurchaseOrderCreatedEvent>
{
    /// <inheritdoc />
    public Task Handle(PurchaseOrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Purchase order {PurchaseOrderId} ({OrderId}) created for supplier {SupplierName} for {TotalAmount}.",
            notification.PurchaseOrderId, notification.OrderId, notification.SupplierName, notification.TotalAmount);
        return Task.CompletedTask;
    }
}
