using Buildline.Platform.Suppliers.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a supplier incident is reported.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     Incident reports are relevant for supplier quality tracking and procurement decision
///     automation planned in future sprints.
/// </remarks>
public class SupplierIncidentReportedEventHandler(ILogger<SupplierIncidentReportedEventHandler> logger)
    : IEventHandler<SupplierIncidentReportedEvent>
{
    /// <inheritdoc />
    public Task Handle(SupplierIncidentReportedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Supplier incident {SupplierIncidentId} ({IncidentId}) reported for supplier {Supplier}. Severity: {Severity}.",
            notification.SupplierIncidentId, notification.IncidentId, notification.Supplier, notification.Severity);
        return Task.CompletedTask;
    }
}
