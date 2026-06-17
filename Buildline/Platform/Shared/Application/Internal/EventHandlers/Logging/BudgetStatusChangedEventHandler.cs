using Buildline.Platform.Analytics.Domain.Model.Events;
using Microsoft.Extensions.Logging;

namespace Buildline.Platform.Shared.Application.Internal.EventHandlers.Logging;

/// <summary>
///     Application event handler that logs each time a budget status is changed.
/// </summary>
/// <param name="logger">Logger used to record the domain event occurrence.</param>
/// <remarks>
///     Budget status transitions are relevant for project dashboards and financial oversight
///     automation planned in future iterations.
/// </remarks>
public class BudgetStatusChangedEventHandler(ILogger<BudgetStatusChangedEventHandler> logger)
    : IEventHandler<BudgetStatusChangedEvent>
{
    /// <inheritdoc />
    public Task Handle(BudgetStatusChangedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "Budget {BudgetId} for project {Project} status changed from {PreviousStatus} to {CurrentStatus}.",
            notification.BudgetId, notification.Project, notification.PreviousStatus, notification.CurrentStatus);
        return Task.CompletedTask;
    }
}
