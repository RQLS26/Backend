using Buildline.Platform.Inventory.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time inventory stock levels change.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     Stock change events can drive reorder alerts, dashboard refresh signals or integration
///     with procurement systems once those workflows are implemented.
/// </remarks>
public class InventoryStockChangedEventHandler(ILogger<InventoryStockChangedEventHandler> logger)
    : IEventHandler<InventoryStockChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(InventoryStockChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Inventory item {InventoryItemId} ({Sku}) stock changed from {PreviousStock} to {CurrentStock}. Is below minimum: {IsBelowMinimum}.",
            notification.InventoryItemId, notification.Sku, notification.PreviousStock, notification.CurrentStock, notification.IsBelowMinimum);
        return Task.CompletedTask;
    }
}
