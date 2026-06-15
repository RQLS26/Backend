namespace Buildline.Platform.Materials.Interfaces.Rest.Resources;

public record UpdateMaterialResource(
    string Sku,
    string Name,
    string Category,
    string Unit,
    string Project,
    int CurrentStock,
    int MinStock,
    int MaxStock);
