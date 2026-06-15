using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Suppliers.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for supplier directory and incident workflows.
/// </summary>
public static class SupplierErrors
{
    /// <summary>The requested supplier does not exist.</summary>
    public static readonly Error SupplierNotFound = new("Suppliers.SupplierNotFound", "The specified supplier was not found.");
    /// <summary>The requested supplier incident does not exist.</summary>
    public static readonly Error SupplierIncidentNotFound = new("Suppliers.SupplierIncidentNotFound", "The specified supplier incident was not found.");
}
