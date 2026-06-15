using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Delivery.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for delivery tracking workflows.
/// </summary>
public static class DeliveryErrors
{
    /// <summary>The requested delivery does not exist.</summary>
    public static readonly Error DeliveryNotFound = new("Delivery.DeliveryNotFound", "The specified delivery was not found.");
    /// <summary>The referenced purchase order cannot be resolved by Procurement.</summary>
    public static readonly Error PurchaseOrderReferenceNotFound = new("Delivery.PurchaseOrderReferenceNotFound", "The referenced purchase order was not found.");
}
