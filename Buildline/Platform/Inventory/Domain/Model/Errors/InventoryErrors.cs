using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Inventory.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for inventory and category reference data.
/// </summary>
public static class InventoryErrors
{
    /// <summary>The requested inventory item does not exist.</summary>
    public static readonly Error InventoryItemNotFound = new("Inventory.InventoryItemNotFound", "The specified inventory item was not found.");
    /// <summary>The inventory item payload is incomplete or invalid.</summary>
    public static readonly Error InvalidInventoryItemData = new("Inventory.InvalidInventoryItemData", "Invalid inventory item data provided.");
    /// <summary>The requested category reference does not exist.</summary>
    public static readonly Error CategoryNotFound = new("Inventory.CategoryNotFound", "The specified category was not found.");
}
