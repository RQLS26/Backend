using Buildline.Platform.Materials.Domain.Model.Aggregates;
using Buildline.Platform.Materials.Interfaces.Rest.Resources;

namespace Buildline.Platform.Materials.Interfaces.Rest.Transform;

public static class MaterialResourceFromEntityAssembler
{
    public static MaterialResource ToResourceFromEntity(Material material)
    {
        return new MaterialResource(
            material.Id,
            material.Sku,
            material.Name,
            material.Category,
            material.Unit,
            material.Project,
            material.CurrentStock,
            material.MinStock,
            material.MaxStock);
    }
}
