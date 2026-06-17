using Buildline.Platform.Requisition.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a requisition is created.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     This handler demonstrates how the mediator pipeline dispatches domain events to registered
///     consumers. Production handlers could forward notifications to the Communication context or
///     trigger procurement workflows.
/// </remarks>
public class RequisitionCreatedEventHandler(ILogger<RequisitionCreatedEventHandler> logger)
    : IEventHandler<RequisitionCreatedEvent>
{
    /// <inheritdoc />
    public Task Handle(RequisitionCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Requisition {RequisitionId} ({ReqId}) created for project {Project}.",
            notification.RequisitionId, notification.ReqId, notification.Project);
        return Task.CompletedTask;
    }
}
