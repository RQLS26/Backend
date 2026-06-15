namespace Buildline.Platform.Materials.Domain.Model.Commands;

public record UpdateMaterialCommand(
    int MaterialId,
    string Sku,
    string Name,
    string Category,
    string Unit,
    string Project,
    int CurrentStock,
    int MinStock,
    int MaxStock);
