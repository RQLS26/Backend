namespace Buildline.Platform.Materials.Interfaces.Rest.Resources;

public record MaterialResource(
    int Id,
    string Sku,
    string Name,
    string Category,
    string Unit,
    string Project,
    int CurrentStock,
    int MinStock,
    int MaxStock);
