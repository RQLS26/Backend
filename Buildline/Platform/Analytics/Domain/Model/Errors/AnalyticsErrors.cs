using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Analytics.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for analytics budgets and project reference data.
/// </summary>
public static class AnalyticsErrors
{
    /// <summary>The requested budget does not exist.</summary>
    public static readonly Error BudgetNotFound = new("Analytics.BudgetNotFound", "The specified budget was not found.");
    /// <summary>The requested project reference does not exist.</summary>
    public static readonly Error ProjectNotFound = new("Analytics.ProjectNotFound", "The specified project was not found.");
}
