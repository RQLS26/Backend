using Buildline.Platform.Shared.Domain.Model;

namespace Buildline.Platform.Requisition.Domain.Model.Errors;

/// <summary>
///     Domain error catalog for material reference data owned by Requisition.
/// </summary>
public static class MaterialErrors
{
    /// <summary>The requested material reference does not exist.</summary>
    public static readonly Error MaterialNotFound = new("Materials.MaterialNotFound", "The specified material was not found.");
    /// <summary>The material reference payload is incomplete or invalid.</summary>
    public static readonly Error InvalidMaterialData = new("Materials.InvalidMaterialData", "Invalid material data provided.");
}
