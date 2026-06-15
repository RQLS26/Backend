using Buildline.Platform.Materials.Domain.Model.Commands;
using Buildline.Platform.Materials.Interfaces.Rest.Resources;

namespace Buildline.Platform.Materials.Interfaces.Rest.Transform;

public static class UpdateMaterialCommandFromResourceAssembler
{
    public static UpdateMaterialCommand ToCommandFromResource(int materialId, UpdateMaterialResource resource)
    {
        return new UpdateMaterialCommand(
            materialId,
            resource.Sku,
            resource.Name,
            resource.Category,
            resource.Unit,
            resource.Project,
            resource.CurrentStock,
            resource.MinStock,
            resource.MaxStock);
    }
}
