using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Requisition.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for material requisition workflows.
/// </summary>
public static class RequisitionErrors
{
    /// <summary>The requested requisition does not exist.</summary>
    public static readonly Error RequisitionNotFound = new("Requisition.RequisitionNotFound", "The specified requisition was not found.");
    /// <summary>The requisition payload is missing required operational data.</summary>
    public static readonly Error InvalidRequisitionData = new("Requisition.InvalidRequisitionData", "Invalid requisition data provided.");
    /// <summary>The referenced project cannot be resolved by Analytics.</summary>
    public static readonly Error ProjectReferenceNotFound = new("Requisition.ProjectReferenceNotFound", "The referenced project was not found.");
}
