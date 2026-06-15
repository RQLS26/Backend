using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Procurement.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for purchase order and quotation workflows.
/// </summary>
public static class ProcurementErrors
{
    /// <summary>The requested purchase order does not exist.</summary>
    public static readonly Error PurchaseOrderNotFound = new("Procurement.PurchaseOrderNotFound", "The specified purchase order was not found.");
    /// <summary>The requested quotation does not exist.</summary>
    public static readonly Error QuotationNotFound = new("Procurement.QuotationNotFound", "The specified quotation was not found.");
    /// <summary>The supplier cannot be selected for a purchase order.</summary>
    public static readonly Error SupplierReferenceNotSelectable = new("Procurement.SupplierReferenceNotSelectable", "The supplier was not found or is inactive.");
}
